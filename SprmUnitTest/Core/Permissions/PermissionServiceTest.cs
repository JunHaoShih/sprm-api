using MockQueryable.Moq;
using Moq;
using SprmApi.Core.AppUsers;
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
            Mock<IPermissionDao> daoMock = new(MockBehavior.Strict);
            Mock<IAppUserDao> userDaoMock = new(MockBehavior.Strict);
            daoMock.Setup(dao => dao.GetByUserId(userId))
                .Returns(permissions.BuildMock().AsQueryable());
            userDaoMock.Setup(dao => dao.GetAsync(userId))
                .ReturnsAsync(new AppUser { Id = userId });
            PermissionService service = new(daoMock.Object, userDaoMock.Object);
            IEnumerable<PermissionDto> targetPermissions = await service.GetByUserIdAsync(userId);
            Assert.Multiple(() =>
            {
                Assert.That(targetPermissions, Is.Not.Empty);
                Assert.That(targetPermissions.Select(p => p.Id), Is.EquivalentTo(permissions.Select(p => p.Id)));
            });
        }

        private static readonly object[] s_permissionsSaveCase =
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
                new List<SavePermissionDto>
                {
                    new SavePermissionDto
                    {
                        ObjectType = SprmObjectType.PartVersion,
                        CreatePermitted = false,
                        ReadPermitted = false,
                        UpdatePermitted = false,
                        DeletePermitted = false,
                    },
                    new SavePermissionDto
                    {
                        ObjectType = SprmObjectType.PartUsage,
                        CreatePermitted = false,
                        ReadPermitted = false,
                        UpdatePermitted = false,
                        DeletePermitted = false,
                    },
                },
                1,
                "RequestUser",
            },
        };

        [TestCaseSource(nameof(s_permissionsSaveCase))]
        public async Task SaveAsync(List<Permission> permissions, List<SavePermissionDto> dtos, long userId, string requester)
        {
            Mock<IPermissionDao> daoMock = new Mock<IPermissionDao>(MockBehavior.Strict);
            Mock<IAppUserDao> userDaoMock = new(MockBehavior.Strict);
            daoMock.Setup(dao => dao.GetByUserId(userId))
                .Returns(permissions.BuildMock().AsQueryable());
            userDaoMock.Setup(dao => dao.GetAsync(userId))
                .ReturnsAsync(new AppUser { Id = userId });
            int insertCount = 0;
            int updateCount = 0;
            List<Permission> savePermissions = new();
            List<string> requesters = new();
            daoMock.Setup(dao => dao.InsertAsync(It.IsAny<Permission>(), It.IsAny<string>()))
                .Callback<Permission, string>((p, userName) =>
                {
                    insertCount++;
                    savePermissions.Add(p);
                    requesters.Add(userName);
                })
                .ReturnsAsync(new Permission());
            daoMock.Setup(dao => dao.UpdateAsync(It.IsAny<Permission>(), It.IsAny<string>()))
                .Callback<Permission, string>((p, userName) =>
                {
                    updateCount++;
                    savePermissions.Add(p);
                    requesters.Add(userName);
                })
                .Returns(Task.CompletedTask);
            PermissionService service = new(daoMock.Object, userDaoMock.Object);
            await service.SaveAsync(dtos, userId, requester);
            Assert.Multiple(() =>
            {
                Assert.That(insertCount + updateCount, Is.EqualTo(dtos.Count));
                Assert.That(requesters, Has.All.EqualTo(requester));
                Assert.That(savePermissions.Select(p => p.CreatePermitted), Has.All.EqualTo(false));
                Assert.That(savePermissions.Select(p => p.ReadPermitted), Has.All.EqualTo(false));
                Assert.That(savePermissions.Select(p => p.UpdatePermitted), Has.All.EqualTo(false));
                Assert.That(savePermissions.Select(p => p.DeletePermitted), Has.All.EqualTo(false));
            });
        }
    }
}
