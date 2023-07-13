using Moq;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Settings;

namespace SprmUnitTest.Core.Auth
{
    internal class JwtServiceTest
    {
        private static readonly string s_signedKey = "123";

        private ApiSettings _apiSettings;

        [SetUp]
        public void Setup()
        {
            _apiSettings = new ApiSettings("", s_signedKey, "admin", "password", new JwtSettings("TestIssuer", ""));
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
        public async Task GenerateToken(AppUser appUser, List<PermissionDto> permissions)
        {
            Mock<IPermissionService> mock = new(MockBehavior.Strict);
            mock.Setup(x => x.GetByUserIdAsync(appUser.Id))
                .ReturnsAsync(permissions);
            JwtService jwtService = new(_apiSettings, mock.Object);
            string token = await jwtService.GenerateToken(appUser);
            JwtPayload payload = jwtService.DecryptToken(token);
            Assert.That(appUser.Username, Is.EqualTo(payload.Subject));
        }
    }
}
