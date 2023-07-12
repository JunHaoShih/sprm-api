using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Permissions;
using SprmApi.EFs;

namespace SprmUnitTest.Core.Permissions
{
    internal class PermissionDaoTest
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
        public void GetByUserId(List<Permission> permissions, long userId)
        {
            Mock<SprmContext> mock = new Mock<SprmContext>(new DbContextOptions<SprmContext>());
            mock.Setup(context => context.Permissions)
                .Returns(permissions.BuildMock().BuildMockDbSet().Object);
            PermissionDao dao = new PermissionDao(mock.Object);
            IQueryable<Permission> targetPermissions = dao.GetByUserId(userId);
            Assert.Multiple(() =>
            {
                Assert.That(targetPermissions, Is.Not.Empty);
                Assert.That(targetPermissions, Is.EquivalentTo(permissions));
            });
        }
    }
}
