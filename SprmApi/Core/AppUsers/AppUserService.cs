using System.Security.Cryptography;
using System.Text;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.MiddleWares;
using SprmApi.Settings;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser service
    /// </summary>
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserDao _appUserD;

        private readonly ApiSettings _apiSettings;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserDao"></param>
        /// <param name="apiSettings"></param>
        /// <param name="headerData"></param>
        public AppUserService(IAppUserDao appUserDao, ApiSettings apiSettings, HeaderData headerData)
        {
            _appUserD = appUserDao;
            _apiSettings = apiSettings;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<AppUser> CreateAppUserAsync(CreateAppUserDto createAppUserDTO)
        {
            AppUser? creator = await _appUserD.GetByUsernameAsync(_headerData.JWTPayload!.Subject);
            if (creator == null)
            {
                throw new SprmException(ErrorCode.UserNotExist, $"{_headerData.JWTPayload!.Subject} does not exist");
            }
            createAppUserDTO.Password = EncryptPassword(createAppUserDTO.Password);
            return await _appUserD.InsertAsync(createAppUserDTO, creator);
        }

        /// <inheritdoc/>
        public async Task<bool> CreateDefaultAdminAsync()
        {
            AppUser? defaultAdmin = await _appUserD.GetByUsernameAsync(_apiSettings.DefaultAdmin);
            if (defaultAdmin != null)
            {
                return false;
            }
            string passwordHash = EncryptPassword(_apiSettings.DefaultPassword);
            await _appUserD.InsertDefaultAsync(new CreateAppUserDto
            {
                Username = _apiSettings.DefaultAdmin,
                Password = passwordHash,
                IsAdmin = true,
                FullName = "System administrator",
                Remarks = "Created by system",
            });
            return true;
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetByAuthenticateAsync(string username, string password)
        {
            string passwordHash = EncryptPassword(password);
            return await _appUserD.GetByAuthenticateAsync(username, passwordHash);
        }

        /// <inheritdoc/>
        public OffsetPagination<AppUserDto> GetByPattern(string? pattern, OffsetPaginationInput input)
        {
            IQueryable<AppUser> users = _appUserD.GetByPattern(pattern);
            IQueryable<AppUserDto> dtos = users.Select(user => AppUserDto.Parse(user));
            OffsetPagination<AppUserDto> offsetPagination = new(dtos, input);
            return offsetPagination;
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetByUsernameAsync(string username) => await _appUserD.GetByUsernameAsync(username);

        /// <inheritdoc/>
        public async Task<AppUser?> GetByIdAsync(long id) => await _appUserD.GetAsync(id);

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
