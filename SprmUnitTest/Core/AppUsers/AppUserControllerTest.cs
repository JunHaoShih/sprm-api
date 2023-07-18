using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.AppUsers;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.MiddleWares;
using SprmApi.Settings;
using System;
using System.Linq;
using System.Text.Json;

namespace SprmUnitTest.Core.AppUsers
{
    internal class AppUserControllerTest
    {
        private static readonly string s_requestUsername = "RequestUser";

        private HeaderData _headerData;

        private PaginationData _paginationData;

        [SetUp]
        public void Setup()
        {
            _headerData = new HeaderData
            {
                Bearer = string.Empty,
                JWTPayload = new SprmApi.Core.Auth.JwtPayload
                {
                    Subject = s_requestUsername
                }
            };
            _paginationData = new PaginationData();
        }

        private static readonly object[] s_addAppUserCase =
        {
            new object[]
            {
                new CreateAppUserDto
                {
                    Username = "Username",
                    FullName = "Full name",
                    IsAdmin = false,
                },
            }
        };

        [TestCaseSource(nameof(s_addAppUserCase))]
        public async Task CreateUserAsync(CreateAppUserDto dto)
        {
            Mock<IAppUserService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(s => s.CreateAppUserAsync(dto))
                .ReturnsAsync(new AppUser { Id = 1, CustomValues = JsonSerializer.SerializeToDocument(new Dictionary<string, string>()) });
            AppUserController controller = new(serviceMock.Object, _headerData, _paginationData);
            OkObjectResult? result = await controller.Post(dto) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        private static readonly object[] s_getSelfCase =
        {
            new object[]
            {
                new AppUser
                {
                    Id = 1,
                    Username = s_requestUsername,
                    FullName = "Full name",
                    IsAdmin = false,
                    CustomValues = JsonSerializer.SerializeToDocument(new Dictionary<string, string>()),
                },
            }
        };

        [TestCaseSource(nameof(s_getSelfCase))]
        public async Task GetSelfAsync(AppUser self)
        {
            Mock<IAppUserService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(s => s.GetByUsernameAsync(_headerData.JWTPayload.Subject))
                .ReturnsAsync(self);
            AppUserController controller = new(serviceMock.Object, _headerData, _paginationData);
            OkObjectResult? result = await controller.GetCurrentUser() as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetSelfFailedAsync()
        {
            Mock<IAppUserService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(s => s.GetByUsernameAsync(_headerData.JWTPayload.Subject))
                .ReturnsAsync(value: null);
            AppUserController controller = new(serviceMock.Object, _headerData, _paginationData);
            SprmAuthException? ex = Assert.ThrowsAsync<SprmAuthException>(() => controller.GetCurrentUser());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.Error));
        }

        private static readonly object[] s_fuzzySearchCase =
        {
            new object[]
            {
                new List<AppUserDto>
                {
                    new AppUserDto
                    {
                        Id = 1,
                        Username = "Test",
                    },
                    new AppUserDto
                    {
                        Id = 2,
                        Username = "Test2",
                    }
                },
                "Test%",
                new OffsetPaginationInput
                {
                    Page = 1,
                    PerPage = 1,
                },
            }
        };

        [TestCaseSource(nameof(s_fuzzySearchCase))]
        public async Task FuzzySearch(List<AppUserDto> users, string? pattern, OffsetPaginationInput input)
        {
            Mock<IAppUserService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(dao => dao.GetByPattern(pattern, input))
                .Returns(new OffsetPagination<AppUserDto>(users.BuildMock().AsQueryable(), input));
            AppUserController controller = new(serviceMock.Object, _headerData, _paginationData);
            OkObjectResult? result = await controller.FuzzySearch(pattern, input) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }
    }
}
