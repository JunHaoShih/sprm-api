using Microsoft.EntityFrameworkCore;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.EFs;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser DAO
    /// </summary>
    public class AppUserDao : IAppUserDao
    {
        private readonly SprmContext _sprmContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smpmContext"></param>
        public AppUserDao(SprmContext smpmContext) => _sprmContext = smpmContext;

        /// <inheritdoc/>
        public async Task<AppUser?> GetByAuthenticateAsync(string username, string passwordHash)
        {
            return await _sprmContext.AppUsers
                .Where(user => user.Username == username && user.Password == passwordHash)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<AppUser> InsertAsync(CreateAppUserDto newAppUser, AppUser creator)
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
        public async Task<AppUser> InsertDefaultAsync(CreateAppUserDto newAppUser)
        {
            AppUser entity = newAppUser.ToEntity();
            entity.CreateUser = newAppUser.Username;
            entity.UpdateUser = newAppUser.Username;
            _sprmContext.Add(entity);
            await _sprmContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task<AppUser?> GetAsync(long id)
        {
            AppUser? user = await _sprmContext.AppUsers
                .SingleOrDefaultAsync(user => user.Id == id);
            return user;
        }

        /// <inheritdoc/>
        public IQueryable<AppUser> GetByPattern(string? pattern)
        {
            if (pattern == null)
            {
                return _sprmContext.AppUsers.AsQueryable();
            }
            return _sprmContext.AppUsers
                .Where(user => EF.Functions.Like(user.Username, pattern) || EF.Functions.Like(user.FullName, pattern));
        }
    }
}
