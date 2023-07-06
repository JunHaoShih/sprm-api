using System.Security.Cryptography;
using System.Text;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.AppUsers.DTOs;
using SprmApi.MiddleWares;
using SprmApi.Settings;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser service
    /// </summary>
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserDAO _appUserDAO;

        private readonly ApiSettings _apiSettings;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserDAO"></param>
        /// <param name="apiSettings"></param>
        /// <param name="headerData"></param>
        public AppUserService(IAppUserDAO appUserDAO, ApiSettings apiSettings, HeaderData headerData)
        {
            _appUserDAO = appUserDAO;
            _apiSettings = apiSettings;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<AppUser> CreateAppUserAsync(CreateAppUserDto createAppUserDTO)
        {
            AppUser? creator = await _appUserDAO.GetByUsernameAsync(_headerData.JWTPayload!.Subject);
            if (creator == null)
            {
                throw new SprmException(ErrorCode.UserNotExist, $"{_headerData.JWTPayload!.Subject} does not exist");
            }
            createAppUserDTO.Password = EncryptPassword(createAppUserDTO.Password);
            return await _appUserDAO.InsertAsync(createAppUserDTO, creator);
        }

        /// <inheritdoc/>
        public async Task<bool> CreateDefaultAdminAsync()
        {
            AppUser? defaultAdmin = await _appUserDAO.GetByUsernameAsync(_apiSettings.DefaultAdmin);
            if (defaultAdmin != null)
            {
                return false;
            }
            string passwordHash = EncryptPassword(_apiSettings.DefaultPassword);
            await _appUserDAO.InsertDefaultAsync(new CreateAppUserDto
            {
                Username = _apiSettings.DefaultAdmin,
                Password = passwordHash,
                FullName = "System administrator",
            });
            return true;
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetByAuthenticateAsync(string username, string password)
        {
            var passwordHash = EncryptPassword(password);
            return await _appUserDAO.GetByAuthenticateAsync(username, passwordHash);
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetByUsernameAsync(string username) => await _appUserDAO.GetByUsernameAsync(username);

        /// <summary>
        /// Encrypt user password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string EncryptPassword(string password)
        {
            string passwordHash;
            var keyBytes = Encoding.UTF8.GetBytes(_apiSettings.SignKey);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            using (var hmacSHA256 = new HMACSHA256(keyBytes))
            {
                var hashBytes = hmacSHA256.ComputeHash(passwordBytes);
                passwordHash = Convert.ToBase64String(hashBytes);
            }
            return passwordHash;
        }
    }
}
