using MockQueryable.Moq;
using Moq;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;

namespace SprmUnitTest.Core.Permissions
{
    internal class PermissionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_permissionsCase =
        {
            new object[]
            {
                new List<Permission>
                {
                    new Permission
                    {
                        Id = 1,
                        UserId = 1,
                        ObjectTypeId = (long)SprmObjectType.PartVersion,
                        CreatePermitted = true,
                        ReadPermitted = true,
                        UpdatePermitted = true,
                        DeletePermitted = true,
                    },
                    new Permission
                    {
                        Id = 2,
                        UserId = 1,
                        ObjectTypeId = (long)SprmObjectType.PartUsage,
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
        public async Task GetByUserId(List<Permission> permissions, long userId)
        {
            Mock<IPermissionDao> daoMock = new Mock<IPermissionDao>(MockBehavior.Strict);
            daoMock.Setup(dao => dao.GetByUserId(userId))
                .Returns(permissions.BuildMock().AsQueryable());
            PermissionService service = new(daoMock.Object);
            IEnumerable<PermissionDto> targetPermissions = await service.GetByUserIdAsync(userId);
            Assert.Multiple(() =>
            {
                Assert.That(targetPermissions, Is.Not.Empty);
                Assert.That(targetPermissions.Select(p => p.Id), Is.EquivalentTo(permissions.Select(p => p.Id)));
            });
        }
    }
}
