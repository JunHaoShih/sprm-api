using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SprmApi.Core.ObjectTypes;

namespace SprmUnitTest.Core.ObjectTypes
{
    internal class ObjectTypeControllerTest
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
        public async Task GetAllAsync(List<ObjectType> makeTypes)
        {
            Mock<IObjectTypeService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(makeTypes.BuildMock().AsQueryable());
            ObjectTypeController service = new(serviceMock.Object);
            OkObjectResult? result = await service.GetAll() as OkObjectResult; ;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
