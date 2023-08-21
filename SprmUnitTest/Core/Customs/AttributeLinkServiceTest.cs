using Moq;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.Customs;
using SprmApi.Core.Customs.Dto;
using SprmApi.Core.ObjectTypes;
using SprmApi.MiddleWares;

namespace SprmUnitTest.Core.Customs
{
    internal class AttributeLinkServiceTest
    {
        private static readonly string s_requestUsername = "RequestUser";

        private HeaderData _headerData;

        [SetUp]
        public void Setup()
        {
            _headerData = new HeaderData
            {
                Bearer = string.Empty,
                JWTPayload = new SprmApi.Core.Auth.JwtAccessPayload
                {
                    Subject = s_requestUsername
                }
            };
        }

        [Test]
        public async Task GetByObjectTypeIdSuccessAsync()
        {
            SprmObjectType objectType = SprmObjectType.PartVersion;
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(objectType))
                .ReturnsAsync(new ObjectType { Id = (long)objectType });
            SprmObjectType expectedInput = SprmObjectType.Unknown;
            attributeLinkDaoMock
                .Setup(x => x.GetByObjectTypeAsync(It.IsAny<SprmObjectType>()))
                .Callback<SprmObjectType>(objType => expectedInput = objType)
                .ReturnsAsync(new List<AttributeLink>());
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            await service.GetByObjectTypeIdAsync(objectType);
            Assert.Multiple(() =>
            {
                Assert.That(expectedInput, Is.Not.EqualTo(SprmObjectType.Unknown));
                Assert.That(expectedInput, Is.EqualTo(objectType));
            });
        }

        [Test]
        public void GetByObjectTypeIdFailed()
        {
            SprmObjectType objectType = SprmObjectType.PartVersion;
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(objectType))
                .ReturnsAsync(value: null);
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.GetByObjectTypeIdAsync(objectType));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        private static readonly object[] s_deleteCase =
        {
            new object[]
            {
                new DeleteAttributeLinksDto
                {
                    ObjectTypeId = SprmObjectType.PartVersion,
                    AttributeIds = new List<long>{1},
                }
            }
        };

        [TestCaseSource(nameof(s_deleteCase))]
        public void DeleteButObjectTypeNotExist(DeleteAttributeLinksDto deleteDTO)
        {
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(deleteDTO.ObjectTypeId))
                .ReturnsAsync(value: null);
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.DeleteAsync(deleteDTO));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_deleteCase))]
        public void DeleteButAttributeNotExist(DeleteAttributeLinksDto deleteDTO)
        {
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(deleteDTO.ObjectTypeId))
                .ReturnsAsync(new ObjectType { Id = (long)deleteDTO.ObjectTypeId });
            foreach (long attributeId in deleteDTO.AttributeIds)
            {
                customAttributeDaoMock
                    .Setup(x => x.GetByIdAsync(attributeId))
                    .ReturnsAsync(value: null);
            }
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.DeleteAsync(deleteDTO));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_deleteCase))]
        public void DeleteButAttributeLinkNotExist(DeleteAttributeLinksDto deleteDTO)
        {
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(deleteDTO.ObjectTypeId))
                .ReturnsAsync(new ObjectType { Id = (long)deleteDTO.ObjectTypeId });
            foreach (long attributeId in deleteDTO.AttributeIds)
            {
                customAttributeDaoMock
                    .Setup(x => x.GetByIdAsync(attributeId))
                    .ReturnsAsync(new CustomAttribute());
                attributeLinkDaoMock
                    .Setup(x => x.Get(deleteDTO.ObjectTypeId, attributeId))
                    .ReturnsAsync(value: null);
            }
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.DeleteAsync(deleteDTO));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_deleteCase))]
        public async Task DeleteSuccess(DeleteAttributeLinksDto deleteDTO)
        {
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(deleteDTO.ObjectTypeId))
                .ReturnsAsync(new ObjectType { Id = (long)deleteDTO.ObjectTypeId });
            List<long> expectedInputs = new();
            foreach (long attributeId in deleteDTO.AttributeIds)
            {
                customAttributeDaoMock
                    .Setup(x => x.GetByIdAsync(attributeId))
                    .ReturnsAsync(new CustomAttribute());
                attributeLinkDaoMock
                    .Setup(x => x.Get(deleteDTO.ObjectTypeId, attributeId))
                    .ReturnsAsync(new AttributeLink { Id = -1 });
                attributeLinkDaoMock
                    .Setup(x => x.DeleteAsync(It.IsAny<long>()))
                    .Callback<long>(inputId => expectedInputs.Add(inputId))
                    .Returns(Task.CompletedTask);
            }
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            await service.DeleteAsync(deleteDTO);
            Assert.Multiple(() =>
            {
                Assert.That(expectedInputs, Has.Count.EqualTo(deleteDTO.AttributeIds.Count()));
                Assert.That(expectedInputs, Has.All.EqualTo(-1));
            });
        }

        private static readonly object[] s_insertCase =
        {
            new object[]
            {
                new CreateAttributeLinksDto
                {
                    ObjectTypeId = SprmObjectType.PartVersion,
                    AttributeIds = new List<long>{ 1, 2 },
                }
            }
        };

        [TestCaseSource(nameof(s_insertCase))]
        public async Task InsertSuccess(CreateAttributeLinksDto createDTO)
        {
            Mock<IObjectTypeDao> objTypeDaoMock = new(MockBehavior.Strict);
            Mock<IAttributeLinkDao> attributeLinkDaoMock = new(MockBehavior.Strict);
            Mock<ICustomAttributeDao> customAttributeDaoMock = new(MockBehavior.Strict);
            objTypeDaoMock
                .Setup(x => x.GetByIdAsync(createDTO.ObjectTypeId))
                .ReturnsAsync(new ObjectType { Id = (long)createDTO.ObjectTypeId });
            List<long> expectedAttributeIds = new();
            foreach (long attributeId in createDTO.AttributeIds)
            {
                customAttributeDaoMock
                    .Setup(x => x.GetByIdAsync(attributeId))
                    .ReturnsAsync(new CustomAttribute());
                attributeLinkDaoMock
                    .Setup(x => x.InsertAsync(It.IsAny<SprmObjectType>(), It.IsAny<long>(), It.IsAny<string>()))
                    .Callback<SprmObjectType, long, string>((objType, attributeId, creater) =>
                    {
                        expectedAttributeIds.Add(attributeId);
                    })
                    .ReturnsAsync(new AttributeLink
                    {
                        AttributeId = attributeId,
                        ObjectTypeId = (long)createDTO.ObjectTypeId,
                    });
            }
            AttributeLinkService service = new(attributeLinkDaoMock.Object, objTypeDaoMock.Object, customAttributeDaoMock.Object, _headerData);
            await service.InsertAsync(createDTO);
            Assert.Multiple(() =>
            {
                Assert.That(expectedAttributeIds, Has.Count.EqualTo(createDTO.AttributeIds.Count()));
                Assert.That(expectedAttributeIds, Is.EquivalentTo(createDTO.AttributeIds));
            });
        }
    }
}
