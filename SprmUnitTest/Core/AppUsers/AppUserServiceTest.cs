using System.Text.Json;
using MockQueryable.Moq;
using Moq;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.AppUsers;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.MiddleWares;
using SprmApi.Settings;

namespace SprmUnitTest.Core.AppUsers
{
    public class AppUserServiceTest
    {
        private static readonly string s_requestUsername = "RequestUser";
        private static readonly string s_signedKey = "123";

        private HeaderData _headerData;

        private ApiSettings _apiSettings;

        [SetUp]
        public void Setup()
        {
            _headerData = new HeaderData
            {
                Bearer = string.Empty,
                JWTPayload = new SprmApi.Core.Auth.JwtAccessPayload
                {
                    Subject = s_requestUsername
                }
            };
            _apiSettings = new ApiSettings("", s_signedKey, "admin", "password");
        }

        private static readonly object[] s_createUserCase =
        {
            new object[]
            {
                new CreateAppUserDto
                {
                    Username = "NewUser",
                    Password = "123",
                    FullName = "Haha"
                }
            }
        };

        [TestCaseSource(nameof(s_createUserCase))]
        public async Task CreateUserSuccessAsync(CreateAppUserDto dto)
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            AppUser creater = new AppUser()
            {
                Id = 1,
                Username = _headerData.JWTPayload!.Subject,
                FullName = "FFF",
            };
            daoMock
                .Setup(x => x.GetByUsernameAsync(_headerData.JWTPayload!.Subject))
                .ReturnsAsync(creater);

            CreateAppUserDto? finalDto = null;
            daoMock
                .Setup(x => x.InsertAsync(It.IsAny<CreateAppUserDto>(), It.IsAny<AppUser>()))
                .Callback<CreateAppUserDto, AppUser>((dto, creater) =>
                {
                    finalDto = dto;
                })
                .ReturnsAsync(new AppUser { Id = -1 });
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            AppUser createdUser = await appUserService.CreateAppUserAsync(dto);
            Assert.That(finalDto, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(dto.Username, Is.EqualTo(finalDto.Username));
                Assert.That(dto.Password, Is.EqualTo(finalDto.Password));
                Assert.That(createdUser.Id, Is.EqualTo(-1));
            });
        }

        [TestCaseSource(nameof(s_createUserCase))]
        public void CreateUserFailedAsync(CreateAppUserDto dto)
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetByUsernameAsync(_headerData.JWTPayload!.Subject))
                .ReturnsAsync(value: null);
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => appUserService.CreateAppUserAsync(dto));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.UserNotExist));
        }

        [Test]
        public async Task CreateDefaultUserSuccessAsync()
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetByUsernameAsync(_apiSettings.DefaultAdmin))
                .ReturnsAsync(value: null);

            CreateAppUserDto? dto = null;
            daoMock
                .Setup(x => x.InsertDefaultAsync(It.IsAny<CreateAppUserDto>()))
                .Callback<CreateAppUserDto>(inputDto => dto = inputDto)
                .ReturnsAsync(new AppUser());
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            bool success = await appUserService.CreateDefaultAdminAsync();
            Assert.That(dto, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(dto.IsAdmin, Is.True);
                Assert.That(success, Is.True);
            });
        }

        [Test]
        public async Task CreateDefaultUserFailedAsync()
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            AppUser defaultAdmin = new AppUser()
            {
                Id = 1,
                Username = _apiSettings.DefaultAdmin,
                FullName = "FFF",
            };
            daoMock
                .Setup(x => x.GetByUsernameAsync(_apiSettings.DefaultAdmin))
                .ReturnsAsync(defaultAdmin);
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            bool success = await appUserService.CreateDefaultAdminAsync();
            Assert.That(success, Is.False);
        }

        private static readonly object[] s_userAuth =
        {
            new object[]
            {
                "Username",
                "Password"
            }
        };

        [TestCaseSource(nameof(s_userAuth))]
        public async Task AuthUserAsync(string username, string password)
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            string inputUsername = "";
            string inputPassword = "";
            daoMock
                .Setup(x => x.GetByAuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((username, password) =>
                {
                    inputUsername = username;
                    inputPassword = password;
                })
                .ReturnsAsync(new AppUser() { Id = -1 });
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            await appUserService.GetByAuthenticateAsync(username, password);
            Assert.Multiple(() =>
            {
                Assert.That(inputUsername, Is.EqualTo(username));
                Assert.That(inputPassword, Is.Not.EqualTo(password));
            });
        }

        private static readonly object[] s_fuzzySearchCase =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "A",
                        CustomValues = JsonSerializer.SerializeToDocument(new Dictionary<string, string>())
                    },
                    new AppUser
                    {
                        Id = 2,
                        Username = "AB",
                        CustomValues = JsonSerializer.SerializeToDocument(new Dictionary<string, string>())
                    },
                },
                "%A%",
                new OffsetPaginationInput
                {
                    Page = 1,
                    PerPage = 1,
                }
            }
        };

        [TestCaseSource(nameof(s_fuzzySearchCase))]
        public async Task FuzzySearch(List<AppUser> users, string pattern, OffsetPaginationInput input)
        {
            Mock<IAppUserDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(dao => dao.GetByPattern(pattern))
                .Returns(users.BuildMock().AsQueryable());
            AppUserService appUserService = new(daoMock.Object, _apiSettings, _headerData);
            OffsetPagination<AppUserDto> pageData = appUserService.GetByPattern(pattern, input);
            OffsetPaginationResponse response = pageData.GetResponseHeader();
            List<AppUserDto> list = await pageData.GetPagedListAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.Total, Is.EqualTo(users.Count));
                Assert.That(response.TotalPages, Is.EqualTo(users.Count / input.PerPage));
                Assert.That(response.PreviousPage, Is.Null);
                Assert.That(response.NextPage, Is.EqualTo(2));
                Assert.That(list, Has.Count.EqualTo(input.Page));
            });
        }
    }
}
