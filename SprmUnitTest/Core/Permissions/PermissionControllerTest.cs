using Microsoft.AspNetCore.Mvc;
using Moq;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;

namespace SprmUnitTest.Core.Permissions
{
    internal class PermissionControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_permissionsCase =
        {
            new object[]
            {
                new List<PermissionDto>
                {
                    new PermissionDto
                    {
                        Id = 1,
                        ObjectType = SprmObjectType.PartVersion,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                    new PermissionDto
                    {
                        Id = 2,
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
            PermissionController controller = new(mockService.Object);
            OkObjectResult? result = await controller.GetByUserId(userId) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
