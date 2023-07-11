using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth;
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
                }
            },
        };

        [TestCaseSource(nameof(s_jwtEncryptCase))]
        public void GenerateToken(AppUser appUser)
        {
            JwtService jwtService = new(_apiSettings);
            string token = jwtService.GenerateToken(appUser);
            JwtPayload payload = jwtService.DecryptToken(token);
            Assert.That(appUser.Username, Is.EqualTo(payload.Subject));
        }
    }
}
