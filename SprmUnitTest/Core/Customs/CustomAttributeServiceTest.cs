using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Customs;
using SprmApi.Core.Customs.Dto;
using SprmApi.MiddleWares;

namespace SprmUnitTest.Core.Customs
{
    internal class CustomAttributeServiceTest
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

        private static readonly object[] s_attributeUpdateCase =
        {
            new object[]
            {
                1,
                new UpdateCustomAttributeDto
                {
                    Number = "HEIGHT",
                    Name = "Height",
                    AttributeType = AttributeType.String,
                    DisplayType = DisplayType.Value,
                }
            }
        };

        [TestCaseSource(nameof(s_attributeUpdateCase))]
        public void UpdateSuccessAsync(long id, UpdateCustomAttributeDto dto)
        {
            Mock<ICustomAttributeDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(value: null);
            CustomAttributeService service = new(daoMock.Object, _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.UpdateAsync(id, dto));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_attributeUpdateCase))]
        public async Task UpdateFailedAsync(long id, UpdateCustomAttributeDto dto)
        {
            CustomAttribute foundAttribute = new CustomAttribute { Id = id };
            string updaterUsername = "";
            Mock<ICustomAttributeDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(foundAttribute);
            daoMock
                .Setup(x => x.UpdateAsync(It.IsAny<CustomAttribute>(), It.IsAny<string>()))
                .Callback<CustomAttribute, string>((ca, updater) =>
                {
                    updaterUsername = updater;
                })
                .Returns(Task.CompletedTask);
            CustomAttributeService service = new(daoMock.Object, _headerData);
            await service.UpdateAsync(id, dto);
            Assert.Multiple(() =>
            {
                Assert.That(dto.Number, Is.EqualTo(foundAttribute.Number));
                Assert.That(dto.Name, Is.EqualTo(foundAttribute.Name));
                Assert.That(dto.DisplayType, Is.EqualTo(foundAttribute.DisplayType));
                Assert.That(dto.AttributeType, Is.EqualTo(foundAttribute.AttributeType));
                Assert.That(_headerData.JWTPayload.Subject, Is.EqualTo(updaterUsername));
            });
        }

        private static readonly object[] s_attributeInsertCase =
        {
            new object[]
            {
                new CreateCustomAttributeDto
                {
                    Number = "HEIGHT",
                    Name = "Height",
                    AttributeType = AttributeType.String,
                    DisplayType = DisplayType.Value,
                }
            }
        };

        [TestCaseSource(nameof(s_attributeInsertCase))]
        public async Task InsertAsync(CreateCustomAttributeDto dto)
        {
            string createUsername = "";
            Mock<ICustomAttributeDao> daoMock = new(MockBehavior.Strict);
            daoMock
                .Setup(x => x.InsertAsync(It.IsAny<CreateCustomAttributeDto>(), It.IsAny<string>()))
                .Callback<CreateCustomAttributeDto, string>((createDto, creater) =>
                {
                    createUsername = creater;
                })
                .ReturnsAsync(new CustomAttribute() { Id = 1 });
            CustomAttributeService service = new(daoMock.Object, _headerData);
            CustomAttribute newAttribute = await service.InsertAsync(dto);
            Assert.Multiple(() =>
            {
                Assert.That(newAttribute.Id, Is.EqualTo(1));
                Assert.That(_headerData.JWTPayload.Subject, Is.EqualTo(createUsername));
                Assert.That(_headerData.JWTPayload.Subject, Is.EqualTo(createUsername));
            });
        }
    }
}
