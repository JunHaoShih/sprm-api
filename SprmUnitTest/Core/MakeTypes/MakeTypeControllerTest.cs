using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.MakeTypes.Dto;

namespace SprmUnitTest.Core.MakeTypes
{
    internal class MakeTypeControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_makeTypesCase =
        {
            new object[]
            {
                new List<MakeTypeDto>
                {
                    new MakeTypeDto
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new MakeTypeDto
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
            }
        };

        [TestCaseSource(nameof(s_makeTypesCase))]
        public async Task GetAllAsync(List<MakeTypeDto> makeTypes)
        {
            Mock<IMakeTypeService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(x => x.GetAll())
                .Returns(makeTypes.BuildMock().AsQueryable());
            MakeTypeController service = new(serviceMock.Object);
            OkObjectResult? result = await service.GetAll() as OkObjectResult; ;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
