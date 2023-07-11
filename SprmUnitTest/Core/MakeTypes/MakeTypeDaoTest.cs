using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.MakeTypes;
using SprmApi.EFs;

namespace SprmUnitTest.Core.MakeTypes
{
    internal class MakeTypeDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_makeTypesCase =
        {
            new object[]
            {
                new List<MakeType>
                {
                    new MakeType
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new MakeType
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
            }
        };

        [TestCaseSource(nameof(s_makeTypesCase))]
        public void GetAll(List<MakeType> makeTypes)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.MakeTypes)
                .Returns(makeTypes.BuildMock().BuildMockDbSet().Object);
            MakeTypeDao dao = new(mock.Object);
            List<MakeType> all = dao.GetAll().ToList();
            Assert.That(all, Is.EquivalentTo(makeTypes));
        }
    }
}
