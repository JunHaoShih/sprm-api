using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.ObjectTypes;
using SprmApi.EFs;

namespace SprmUnitTest.Core.ObjectTypes
{
    internal class ObjectTypeDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_objectTypesCase =
        {
            new object[]
            {
                new List<ObjectType>
                {
                    new ObjectType
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new ObjectType
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
            }
        };

        [TestCaseSource(nameof(s_objectTypesCase))]
        public async Task GetAllAsync(List<ObjectType> objectTypes)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.ObjectTypes)
                .Returns(objectTypes.BuildMock().BuildMockDbSet().Object);
            ObjectTypeDao dao = new(mock.Object);
            IEnumerable<ObjectType> all = await dao.GetAllAsync();
            Assert.That(all, Is.EquivalentTo(objectTypes));
        }

        private static readonly object[] s_objectTypesByIdSuccessCase =
        {
            new object[]
            {
                new List<ObjectType>
                {
                    new ObjectType
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new ObjectType
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
                SprmObjectType.PartVersion,
            }
        };

        [TestCaseSource(nameof(s_objectTypesByIdSuccessCase))]
        public async Task GetByIdSuccessAsync(List<ObjectType> objectTypes, SprmObjectType objType)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.ObjectTypes)
                .Returns(objectTypes.BuildMock().BuildMockDbSet().Object);
            ObjectTypeDao dao = new(mock.Object);
            ObjectType? target = await dao.GetByIdAsync(objType);
            Assert.That(target, Is.Not.Null);
        }

        private static readonly object[] s_objectTypesByIdFailedCase =
        {
            new object[]
            {
                new List<ObjectType>
                {
                    new ObjectType
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new ObjectType
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
                SprmObjectType.RoutingUsage,
            }
        };

        [TestCaseSource(nameof(s_objectTypesByIdFailedCase))]
        public async Task GetByIdFailedAsync(List<ObjectType> objectTypes, SprmObjectType objType)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.ObjectTypes)
                .Returns(objectTypes.BuildMock().BuildMockDbSet().Object);
            ObjectTypeDao dao = new(mock.Object);
            ObjectType? target = await dao.GetByIdAsync(objType);
            Assert.That(target, Is.Null);
        }
    }
}
