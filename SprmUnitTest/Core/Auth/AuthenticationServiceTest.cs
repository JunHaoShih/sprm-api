using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
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
                new AuthenticateDto
                {
                    Username = "username",
                    Password = "password",
                }
            }
        };

        [TestCaseSource(nameof(s_user_auth_case))]
        public async Task AuthSuccessAsync(AuthenticateDto dto)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByAuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AppUser { Id = -1 });
            AuthenticationService service = new(mock.Object);
            AppUser user = await service.Authenticate(dto);
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null);
                Assert.That(user.Id, Is.EqualTo(-1));
            });
        }

        [TestCaseSource(nameof(s_user_auth_case))]
        public void AuthFailedAsync(AuthenticateDto dto)
        {
            Mock<IAppUserService> mock = new();
            mock
                .Setup(x => x.GetByAuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(value: null);
            AuthenticationService service = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.Authenticate(dto));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.IncorrectUsernameOrPassword));
        }
    }
}
