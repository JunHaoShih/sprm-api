using Moq;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth;
using SprmApi.Core.Auth.Dto;

namespace SprmUnitTest.Core.Auth
{
    internal class AuthenticationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_user_auth_case =
        {
            new object[]
            {
                new AuthenticateRequestDto
                {
                    Username = "username",
                    Password = "password",
                },
                "access",
                "refresh",
            }
        };

        [TestCaseSource(nameof(s_user_auth_case))]
        public async Task AuthSuccessAsync(AuthenticateRequestDto dto, string accessToken, string refreshToken)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByAuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AppUser { Id = -1 });
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.GenerateAccessToken(It.IsAny<AppUser>()))
                .ReturnsAsync(accessToken);
            jwtServiceMock
                .Setup(service => service.GenerateRefreshToken(It.IsAny<AppUser>()))
                .Returns(refreshToken);
            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            AuthenticateResponseDto response = await service.Authenticate(dto);
            Assert.Multiple(() =>
            {
                Assert.That(response.Token, Is.EqualTo(accessToken));
                Assert.That(response.RefreshToken, Is.EqualTo(refreshToken));
            });
        }

        [Test]
        public void AuthFailedAsync()
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByAuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(value: null);
            Mock<IJwtService> jwtServiceMock = new();
            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.Authenticate(new AuthenticateRequestDto()));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.IncorrectUsernameOrPassword));
        }

        private static readonly object[] s_user_refresh_case =
        {
            new object[]
            {
                new RefreshTokenDto
                {
                    RefreshToken = "refresh",
                },
                new JwtBasePayload
                {
                    Subject = "Yeah",
                },
                "access",
                "refresh"
            }
        };

        [TestCaseSource(nameof(s_user_refresh_case))]
        public async Task RefreshSuccessAsync(RefreshTokenDto dto, JwtBasePayload payload, string accessToken, string refreshToken)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByUsernameAsync(payload.Subject))
                .ReturnsAsync(new AppUser { Id = -1 });
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.DecryptToken<JwtBasePayload>(dto.RefreshToken))
                .Returns(payload);
            jwtServiceMock
                .Setup(service => service.GenerateAccessToken(It.IsAny<AppUser>()))
                .ReturnsAsync(accessToken);
            jwtServiceMock
                .Setup(service => service.GenerateRefreshToken(It.IsAny<AppUser>()))
                .Returns(refreshToken);
            jwtServiceMock
                .Setup(service => service.IsRefreshTokenWhiteList(It.IsAny<AppUser>(), It.IsAny<string>()))
                .Returns(true);


            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            AuthenticateResponseDto response = await service.Refresh(dto);
            Assert.Multiple(() =>
            {
                Assert.That(response.Token, Is.EqualTo(accessToken));
                Assert.That(response.RefreshToken, Is.EqualTo(refreshToken));
            });
        }

        private static readonly object[] s_user_refresh_failed_case =
        {
            new object[]
            {
                new RefreshTokenDto
                {
                    RefreshToken = "refresh",
                },
                new JwtBasePayload
                {
                    Subject = "Yeah",
                },
            }
        };

        [TestCaseSource(nameof(s_user_refresh_failed_case))]
        public void RefreshFailedAsync(RefreshTokenDto dto, JwtBasePayload payload)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByUsernameAsync("Not important"))
                .ReturnsAsync(value: null);
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.DecryptToken<JwtBasePayload>(dto.RefreshToken))
                .Returns(payload);
            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.Authenticate(new AuthenticateRequestDto()));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.IncorrectUsernameOrPassword));
        }

        private static readonly object[] s_user_refresh_not_whitelist_case =
        {
            new object[]
            {
                new RefreshTokenDto
                {
                    RefreshToken = "refresh",
                },
                new JwtBasePayload
                {
                    Subject = "Yeah",
                },
            }
        };

        [TestCaseSource(nameof(s_user_refresh_not_whitelist_case))]
        public void RefreshNotWhiteListAsync(RefreshTokenDto dto, JwtBasePayload payload)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByUsernameAsync(payload.Subject))
                .ReturnsAsync(new AppUser { Id = -1 });
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.DecryptToken<JwtBasePayload>(dto.RefreshToken))
                .Returns(payload);
            jwtServiceMock
                .Setup(service => service.IsRefreshTokenWhiteList(It.IsAny<AppUser>(), It.IsAny<string>()))
                .Returns(false);


            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            SprmAuthException? ex = Assert.CatchAsync<SprmAuthException>(() => service.Refresh(dto));

            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.InvalidToken));
        }

        private static readonly object[] s_user_logout_case =
        {
            new object[]
            {
                new RefreshTokenDto
                {
                    RefreshToken = "refresh",
                },
                new JwtBasePayload
                {
                    Subject = "Yeah",
                },
                "refresh"
            }
        };

        [TestCaseSource(nameof(s_user_logout_case))]
        public async Task LogoutSuccessAsync(RefreshTokenDto dto, JwtBasePayload payload, string refreshToken)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByUsernameAsync(payload.Subject))
                .ReturnsAsync(new AppUser { Id = -1, Username = payload.Subject });
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.DecryptToken<JwtBasePayload>(dto.RefreshToken))
                .Returns(payload);

            string targetUsername = string.Empty;
            string targetToken = string.Empty;
            jwtServiceMock
                .Setup(service => service.RemoveRefreshToken(It.IsAny<AppUser>(), It.IsAny<string>()))
                .Callback<AppUser, string>((user, token) =>
                {
                    targetUsername = user.Username;
                    targetToken = token;
                });


            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            await service.Logout(dto);
            Assert.Multiple(() =>
            {
                Assert.That(targetUsername, Is.EqualTo(payload.Subject));
                Assert.That(targetToken, Is.EqualTo(refreshToken));
            });
        }

        private static readonly object[] s_user_logout_failed_case =
        {
            new object[]
            {
                new RefreshTokenDto
                {
                    RefreshToken = "refresh",
                },
                new JwtBasePayload
                {
                    Subject = "Yeah",
                },
            }
        };

        [TestCaseSource(nameof(s_user_logout_failed_case))]
        public void LogoutFailedAsync(RefreshTokenDto dto, JwtBasePayload payload)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByUsernameAsync(payload.Subject))
                .ReturnsAsync(value: null);
            Mock<IJwtService> jwtServiceMock = new();
            jwtServiceMock
                .Setup(service => service.DecryptToken<JwtBasePayload>(dto.RefreshToken))
                .Returns(payload);

            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            SprmAuthException? ex = Assert.ThrowsAsync<SprmAuthException>(() => service.Logout(dto));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.UserNotExist));
        }
    }
}
