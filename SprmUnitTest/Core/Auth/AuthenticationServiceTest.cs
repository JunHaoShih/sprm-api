using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
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
            }
        };

        [TestCaseSource(nameof(s_user_refresh_case))]
        public async Task RefreshSuccessAsync(RefreshTokenDto dto, JwtBasePayload payload, string accessToken)
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
            AuthenticationService service = new(mock.Object, jwtServiceMock.Object);
            AuthenticateResponseDto response = await service.Refresh(dto);
            Assert.Multiple(() =>
            {
                Assert.That(response.Token, Is.EqualTo(accessToken));
                Assert.That(response.RefreshToken, Is.EqualTo(dto.RefreshToken));
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
    }
}
