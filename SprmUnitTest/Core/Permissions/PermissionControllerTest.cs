using Microsoft.AspNetCore.Mvc;
using Moq;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.MiddleWares;

namespace SprmUnitTest.Core.Permissions
{
    internal class PermissionControllerTest
    {
        private static readonly string s_requestUsername = "RequestUser";

        private HeaderData _headerData;

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
        }

        private static readonly object[] s_permissionsCase =
        {
            new object[]
            {
                new List<PermissionDto>
                {
                    new PermissionDto
                    {
                        ObjectType = SprmObjectType.PartVersion,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                    new PermissionDto
                    {
                        ObjectType = SprmObjectType.PartUsage,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                },
                1,
            },
        };

        [TestCaseSource(nameof(s_permissionsCase))]
        public async Task GetByUserIdAsync(List<PermissionDto> dtos, long userId)
        {
            Mock<IPermissionService> mockService = new(MockBehavior.Strict);
            mockService
                .Setup(service => service.GetByUserIdAsync(userId))
                .ReturnsAsync(dtos);
            PermissionController controller = new(mockService.Object, _headerData);
            OkObjectResult? result = await controller.GetByUserId(userId) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        private static readonly object[] s_savePermissionsCase =
        {
            new object[]
            {
                new List<SavePermissionDto>
                {
                    new SavePermissionDto
                    {
                        ObjectType = SprmObjectType.PartVersion,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                    new SavePermissionDto
                    {
                        ObjectType = SprmObjectType.PartUsage,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                },
                1,
            },
        };

        [TestCaseSource(nameof(s_savePermissionsCase))]
        public async Task SaveAsync(List<SavePermissionDto> dtos, long userId)
        {
            Mock<IPermissionService> mockService = new(MockBehavior.Strict);
            mockService
                .Setup(service => service.SaveAsync(dtos, userId, _headerData.JWTPayload.Subject))
                .Returns(Task.CompletedTask);
            PermissionController controller = new(mockService.Object, _headerData);
            OkObjectResult? result = await controller.SaveByUserId(userId, dtos) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
