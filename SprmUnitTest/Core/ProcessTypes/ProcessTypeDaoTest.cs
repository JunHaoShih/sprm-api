using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.ProcessTypes;
using SprmApi.EFs;

namespace SprmUnitTest.Core.ProcessTypes
{
    internal class ProcessTypeDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_processTypesCase =
        {
            new object[]
            {
                new List<ProcessType>
                {
                    new ProcessType
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new ProcessType
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
            }
        };

        [TestCaseSource(nameof(s_processTypesCase))]
        public void GetAll(List<ProcessType> processTypes)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.ProcessTypes)
                .Returns(processTypes.BuildMock().BuildMockDbSet().Object);
            ProcessTypeDao dao = new(mock.Object);
            List<ProcessType> all = dao.GetAll().ToList();
            Assert.That(all, Is.EquivalentTo(processTypes));
        }
    }
}
