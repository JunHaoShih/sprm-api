﻿using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth.Dto;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppUserService _appUserService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserService"></param>
        public AuthenticationService(IAppUserService appUserService) => _appUserService = appUserService;

        /// <inheritdoc/>
        public async Task<AppUser> Authenticate(AuthenticateDto authenticateDTO)
        {
            AppUser? appUser = await _appUserService.GetByAuthenticateAsync(authenticateDTO.Username, authenticateDTO.Password);
            if (appUser == null)
            {
                throw new SprmException(ErrorCode.IncorrectUsernameOrPassword, "");
            }
            return appUser;
        }
    }
}
