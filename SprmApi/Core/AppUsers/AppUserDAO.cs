using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.AppUsers.DTOs;
using SprmApi.EFs;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser DAO
    /// </summary>
    public class AppUserDAO : IAppUserDAO
    {
        private readonly SPRMContext _sprmContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smpmContext"></param>
        public AppUserDAO(SPRMContext smpmContext) => _sprmContext = smpmContext;

        /// <inheritdoc/>
        public async Task<AppUser?> GetByAuthenticateAsync(string username, string passwordHash)
        {
            return await _sprmContext.AppUsers
                .Where(user => user.Username == username && user.Password == passwordHash)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<AppUser> InsertAsync(CreateAppUserDTO newAppUser, AppUser creator)
        {
            AppUser? duplicateUser = await GetByUsernameAsync(newAppUser.Username);
            if (duplicateUser != null)
            {
                throw new SprmException(ErrorCode.UsernameExist, $"{newAppUser.Username}");
            }
            AppUser entity = newAppUser.ToEntity();
            entity.CreateUser = creator.Username;
            entity.UpdateUser = creator.Username;
            _sprmContext.Add(entity);
            await _sprmContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetByUsernameAsync(string username)
        {
            return await _sprmContext.AppUsers
                .Where(user => user.Username == username)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<AppUser> InsertDefaultAsync(CreateAppUserDTO newAppUser)
        {
            AppUser entity = newAppUser.ToEntity();
            entity.CreateUser = newAppUser.Username;
            entity.UpdateUser = newAppUser.Username;
            _sprmContext.Add(entity);
            await _sprmContext.SaveChangesAsync();
            return entity;
        }
    }
}
