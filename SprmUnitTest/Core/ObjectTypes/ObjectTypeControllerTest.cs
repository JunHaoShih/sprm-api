using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SprmCommon.Response;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.ObjectTypes.Dto;

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
                        Id =(long)SprmObjectType.PartVersion,
                        Number = "PartVersion",
                        Name = "One",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.PartUsage,
                        Number = "PartUsage",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.Routing,
                        Number = "Routing",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.RoutingVersion,
                        Number = "RoutingVersion",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.Process,
                        Number = "Process",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.RoutingUsage,
                        Number = "RoutingUsage",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.CustomAttribute,
                        Number = "CustomAttribute",
                        Name = "Two",
                    },
                    new ObjectType
                    {
                        Id =(long)SprmObjectType.AttributeLink,
                        Number = "AttributeLink",
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
            OkObjectResult? result = await service.GetAll() as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [TestCaseSource(nameof(s_objectTypesCase))]
        public async Task GetCustomizableAsync(List<ObjectType> makeTypes)
        {
            Mock<IObjectTypeService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(makeTypes.BuildMock().AsQueryable());
            ObjectTypeController service = new(serviceMock.Object);
            OkObjectResult? result = await service.GetCustomizableTypes() as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            GenericResponse<IEnumerable<ObjectTypeDto>>? foundTypes = result.Value as GenericResponse<IEnumerable<ObjectTypeDto>>;
            Assert.That(foundTypes, Is.Not.Null);
            Assert.That(foundTypes.Content, Is.Not.Null);
            Assert.That(foundTypes.Content.ToList(), Has.Count.EqualTo(5));

        }

        [TestCaseSource(nameof(s_objectTypesCase))]
        public async Task GetPermissibleAsync(List<ObjectType> makeTypes)
        {
            Mock<IObjectTypeService> serviceMock = new(MockBehavior.Strict);
            serviceMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(makeTypes.BuildMock().AsQueryable());
            ObjectTypeController service = new(serviceMock.Object);
            OkObjectResult? result = await service.GetPermissibleTypes() as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            GenericResponse<IEnumerable<ObjectTypeDto>>? foundTypes = result.Value as GenericResponse<IEnumerable<ObjectTypeDto>>;
            Assert.That(foundTypes, Is.Not.Null);
            Assert.That(foundTypes.Content, Is.Not.Null);
            Assert.That(foundTypes.Content.ToList(), Has.Count.EqualTo(7));

        }
    }
}
