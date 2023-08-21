using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.EFs;

namespace SprmUnitTest.Core.AppUsers
{
    public class AppUserDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_user_auth_success_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "asdfgh",
                "12ewrewf",
                "AAA"
            }
        };

        [TestCaseSource(nameof(s_user_auth_success_case))]
        public async Task AuthSuccessAsync(List<AppUser> users, string username, string password, string fullName)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetByAuthenticateAsync(username, password);
            Assert.That(user, Is.Not.Null);
            Assert.That(user.FullName, Is.EqualTo(fullName));
        }

        private static readonly object[] s_user_auth_failed_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "asdfgh",
                "123",
            },
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "123",
                "12ewrewf",
            },
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "123",
                "123",
            },
        };

        [TestCaseSource(nameof(s_user_auth_failed_case))]
        public async Task AuthFailedAsync(List<AppUser> users, string username, string password)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetByAuthenticateAsync(username, password);
            Assert.That(user, Is.Null);
        }

        private static readonly object[] s_user_find_success_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "asdfgh",
                "AAA"
            }
        };

        [TestCaseSource(nameof(s_user_find_success_case))]
        public async Task FindSuccessAsync(List<AppUser> users, string username, string fullName)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetByUsernameAsync(username);
            Assert.That(user, Is.Not.Null);
            Assert.That(user.FullName, Is.EqualTo(fullName));
        }

        private static readonly object[] s_user_find_failed_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                "123",
            },
        };

        [TestCaseSource(nameof(s_user_find_failed_case))]
        public async Task FindFailedAsync(List<AppUser> users, string username)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetByUsernameAsync(username);
            Assert.That(user, Is.Null);
        }

        private static readonly object[] s_user_create_success_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                new CreateAppUserDto
                {
                    Username = "new",
                    Password = "haha",
                    FullName = "BBB",
                },
                new AppUser
                {
                    Id = 1,
                    Username = "asdfgh",
                    Password = "12ewrewf",
                    FullName = "AAA",
                }
            },
        };

        [TestCaseSource(nameof(s_user_create_success_case))]
        public async Task CreateSuccessAsync(List<AppUser> users, CreateAppUserDto dto, AppUser creator)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser user = await dao.InsertAsync(dto, creator);
            Assert.That(user, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(user.Username, Is.EqualTo(dto.Username));
                Assert.That(user.Password, Is.EqualTo(dto.Password));
                Assert.That(user.FullName, Is.EqualTo(dto.FullName));
            });
        }

        private static readonly object[] s_user_create_failed_case =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                new CreateAppUserDto
                {
                    Username = "asdfgh",
                    Password = "haha",
                    FullName = "BBB",
                },
                new AppUser
                {
                    Id = 1,
                    Username = "asdfgh",
                    Password = "12ewrewf",
                    FullName = "AAA",
                }
            },
        };

        [TestCaseSource(nameof(s_user_create_failed_case))]
        public void CreateFailedAsync(List<AppUser> users, CreateAppUserDto dto, AppUser creator)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.InsertAsync(dto, creator));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.UsernameExist));
        }

        private static readonly object[] s_user_create_default_case =
        {
            new object[]
            {
                new List<AppUser>(),
                new CreateAppUserDto
                {
                    Username = "new",
                    Password = "haha",
                    FullName = "BBB",
                },
            },
        };

        [TestCaseSource(nameof(s_user_create_default_case))]
        public async Task CreateDefaultAsync(List<AppUser> users, CreateAppUserDto dto)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser user = await dao.InsertDefaultAsync(dto);
            Assert.That(user, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(user.Username, Is.EqualTo(dto.Username));
                Assert.That(user.Password, Is.EqualTo(dto.Password));
                Assert.That(user.FullName, Is.EqualTo(dto.FullName));
            });
        }

        private static readonly object[] s_userGetByIdSuccessCase =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
               1
            },
        };

        [TestCaseSource(nameof(s_userGetByIdSuccessCase))]
        public async Task GetByIdSuccessAsync(List<AppUser> users, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetAsync(id);
            Assert.That(user, Is.Not.Null);
        }

        private static readonly object[] s_userGetByIdFailedCase =
        {
            new object[]
            {
                new List<AppUser>
                {
                    new AppUser
                    {
                        Id = 1,
                        Username = "asdfgh",
                        Password = "12ewrewf",
                        FullName = "AAA",
                    }
                },
                2
            },
        };

        [TestCaseSource(nameof(s_userGetByIdFailedCase))]
        public async Task GetByIdFailedAsync(List<AppUser> users, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AppUsers).Returns(users.BuildMock().BuildMockDbSet().Object);
            AppUserDao dao = new(mock.Object);
            AppUser? user = await dao.GetAsync(id);
            Assert.That(user, Is.Null);
        }
    }
}
