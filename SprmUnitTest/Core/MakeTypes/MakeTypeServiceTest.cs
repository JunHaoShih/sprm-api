using Moq;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.MakeTypes.Dto;

namespace SprmUnitTest.Core.MakeTypes
{
    internal class MakeTypeServiceTest
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
        public void GetAllAsync(List<MakeType> makeTypes)
        {
            Mock<IMakeTypeDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetAll())
                .Returns(makeTypes.AsQueryable());
            MakeTypeService service = new(daoMock.Object);
            List<MakeTypeDto> allMakeTypes = service.GetAll().ToList();
            Assert.That(allMakeTypes.Select(makeType => makeType.Number), Is.EquivalentTo(makeTypes.Select(makeType => makeType.Number)));
        }
    }
}
