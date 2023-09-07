using Moq;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Core.Redis;
using SprmApi.Settings;
using StackExchange.Redis;

namespace SprmUnitTest.Core.Auth
{
    internal class JwtServiceTest
    {
        private JwtSettings _jwtSettings;

        [SetUp]
        public void Setup()
        {
            _jwtSettings = new JwtSettings("TestIssuer", "");
        }

        private static readonly object[] s_jwtEncryptCase =
        {
            new object[]
            {
                new AppUser
                {
                    Id = 1,
                    Username = "username",
                    Password = "password",
                    FullName = "AAA",
                },
                new List<PermissionDto>
                {
                    new PermissionDto
                    {
                        ObjectType = SprmObjectType.PartVersion,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    }
                }
            },
        };

        [TestCaseSource(nameof(s_jwtEncryptCase))]
        public async Task GenerateAccessToken(AppUser appUser, List<PermissionDto> permissions)
        {
            Mock<IPermissionService> mock = new(MockBehavior.Strict);
            mock.Setup(x => x.GetByUserIdAsync(appUser.Id))
                .ReturnsAsync(permissions);

            Mock<IRedisService> redisMock = new(MockBehavior.Loose);

            JwtService jwtService = new(_jwtSettings, mock.Object, redisMock.Object);
            string token = await jwtService.GenerateAccessToken(appUser);
            JwtAccessPayload payload = jwtService.DecryptToken<JwtAccessPayload>(token);
            Assert.That(appUser.Username, Is.EqualTo(payload.Subject));
        }

        private static readonly object[] s_jwtEncryptRefreshTokenCase =
        {
            new object[]
            {
                new AppUser
                {
                    Id = 1,
                    Username = "username",
                    Password = "password",
                    FullName = "AAA",
                },
            },
        };

        [TestCaseSource(nameof(s_jwtEncryptRefreshTokenCase))]
        public void GenerateRefreshToken(AppUser appUser)
        {
            Mock<IPermissionService> mock = new(MockBehavior.Strict);

            Mock<IDatabase> redisDbMock = new(MockBehavior.Loose);

            Mock<IRedisService> redisMock = new(MockBehavior.Strict);
            redisMock.Setup(x => x.GetDatabase())
                .Returns(redisDbMock.Object);

            JwtService jwtService = new(_jwtSettings, mock.Object, redisMock.Object);
            string token = jwtService.GenerateRefreshToken(appUser);
            JwtBasePayload payload = jwtService.DecryptToken<JwtBasePayload>(token);
            Assert.That(appUser.Username, Is.EqualTo(payload.Subject));
        }
    }
}
