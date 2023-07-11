using Moq;
using SprmApi.Core.ProcessTypes.Dto;
using SprmApi.Core.ProcessTypes;

namespace SprmUnitTest.Core.ProcessTypes
{
    internal class ProcessTypeServiceTest
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
        public void GetAllAsync(List<ProcessType> processTypes)
        {
            Mock<IProcessTypeDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetAll())
                .Returns(processTypes.AsQueryable());
            ProcessTypeService service = new(daoMock.Object);
            List<ProcessTypeDto> allProcessTypes = service.GetAll().ToList();
            Assert.That(
                allProcessTypes.Select(processType => processType.Number),
                Is.EquivalentTo(processTypes.Select(processType => processType.Number))
            );
        }
    }
}
