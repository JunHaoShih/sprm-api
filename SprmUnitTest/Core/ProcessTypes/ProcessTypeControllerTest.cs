using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.ProcessTypes.Dto;
using SprmApi.Core.ProcessTypes;

namespace SprmUnitTest.Core.ProcessTypes
{
    internal class ProcessTypeControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_processTypesCase =
        {
            new object[]
            {
                new List<ProcessTypeDto>
                {
                    new ProcessTypeDto
                    {
                        Id = 1,
                        Number = "M_One",
                        Name = "One",
                    },
                    new ProcessTypeDto
                    {
                        Id = 2,
                        Number = "M_Two",
                        Name = "Two",
                    },
                },
            }
        };

        [TestCaseSource(nameof(s_processTypesCase))]
        public async Task GetAllAsync(List<ProcessTypeDto> processTypes)
        {
            Mock<IProcessTypeService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(x => x.GetAll())
                .Returns(processTypes.BuildMock().AsQueryable());
            ProcessTypeController service = new(serviceMock.Object);
            OkObjectResult? result = await service.GetAll() as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
