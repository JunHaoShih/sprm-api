using Microsoft.AspNetCore.Mvc;
using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.AppUsers.Dto;
using SprmApi.MiddleWares;
using System;
using System.Linq;

namespace SprmUnitTest.Core.AppUsers
{
    internal class AppUserControllerTest
    {
        private static readonly string s_requestUsername = "RequestUser";

        private HeaderData _headerData;

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
                .ReturnsAsync(new AppUser { Id = 1 });
            AppUserController controller = new(serviceMock.Object, _headerData);
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
            AppUserController controller = new(serviceMock.Object, _headerData);
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
            AppUserController controller = new(serviceMock.Object, _headerData);
            SprmAuthException? ex = Assert.ThrowsAsync<SprmAuthException>(() => controller.GetCurrentUser());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.Error));
        }
    }
}
