using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
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

        private static readonly object[] s_permissioInsertSuccessCase =
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
                },
                new Permission
                {
                    UserId = 1,
                    ObjectTypeId = (long)SprmObjectType.PartUsage,
                    CreatePermitted = true,
                    ReadPermitted = true,
                    UpdatePermitted = true,
                    DeletePermitted = true,
                },
                "creater"
            }
        };

        [TestCaseSource(nameof(s_permissioInsertSuccessCase))]
        public async Task InsertSuccessAsync(List<Permission> permissions, Permission newData, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.Permissions).Returns(permissions.BuildMock().BuildMockDbSet().Object);
            PermissionDao dao = new(mock.Object);
            Permission permission = await dao.InsertAsync(newData, creater);
            Assert.Multiple(() =>
            {
                Assert.That(permission.UserId, Is.EqualTo(newData.UserId));
                Assert.That(permission.ObjectTypeId, Is.EqualTo(newData.ObjectTypeId));
                Assert.That(permission.CreatePermitted, Is.EqualTo(newData.CreatePermitted));
                Assert.That(permission.ReadPermitted, Is.EqualTo(newData.ReadPermitted));
                Assert.That(permission.UpdatePermitted, Is.EqualTo(newData.UpdatePermitted));
                Assert.That(permission.DeletePermitted, Is.EqualTo(newData.DeletePermitted));
            });
        }

        private static readonly object[] s_permissioInsertFailedCase =
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
                },
                new Permission
                {
                    UserId = 1,
                    ObjectTypeId = (long)SprmObjectType.PartVersion,
                    CreatePermitted = true,
                    ReadPermitted = true,
                    UpdatePermitted = true,
                    DeletePermitted = true,
                },
                "creater"
            }
        };

        [TestCaseSource(nameof(s_permissioInsertFailedCase))]
        public void InsertFailedAsync(List<Permission> permissions, Permission newData, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.Permissions).Returns(permissions.BuildMock().BuildMockDbSet().Object);
            PermissionDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.InsertAsync(newData, creater));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbInsertDuplicate));
        }

        private static readonly object[] s_permissionUpdateCase =
        {
            new object[]
            {
                new Permission
                {
                    Id = 1,
                    UserId = 1,
                    ObjectTypeId = (long)SprmObjectType.PartVersion,
                    CreatePermitted = false,
                    ReadPermitted = false,
                    UpdatePermitted = false,
                    DeletePermitted = false,
                },
                "updater"
            }
        };

        [TestCaseSource(nameof(s_permissionUpdateCase))]
        public async Task UpdateAsync(Permission entity, string updater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            PermissionDao dao = new(mock.Object);
            await dao.UpdateAsync(entity, updater);
            Assert.That(updater, Is.EqualTo(entity.UpdateUser));
        }
    }
}
