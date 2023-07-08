using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Customs;
using SprmApi.Core.Customs.Dto;
using SprmApi.EFs;

namespace SprmUnitTest.Core.Customs
{
    internal class CustomAttributeDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_attributeDeleteSuccessCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                    new CustomAttribute
                    {
                        Id = 2,
                        Number = "HEIGHT",
                        Name = "Height"
                    },
                },
                1
            }
        };

        [TestCaseSource(nameof(s_attributeDeleteSuccessCase))]
        public async Task DeleteSuccessAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            await dao.DeleteAsync(id);
            Assert.Pass();
        }

        private static readonly object[] s_attributeDeleteFailedCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                },
                2
            }
        };

        [TestCaseSource(nameof(s_attributeDeleteFailedCase))]
        public void DeleteFailedAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.DeleteAsync(id));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_attributeDeleteSuccessCase))]
        public async Task GetByIdFoundAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByIdAsync(id);
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute, Is.EqualTo(attributes.Single(x => x.Id == id)));
        }

        [TestCaseSource(nameof(s_attributeDeleteFailedCase))]
        public async Task GetByIdNotFoundAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByIdAsync(id);
            Assert.That(attribute, Is.Null);
        }

        private static readonly object[] s_attributeGetByNumberSuccessCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                },
                "WEIGHT"
            }
        };

        [TestCaseSource(nameof(s_attributeGetByNumberSuccessCase))]
        public async Task GetByNumberFoundAsync(List<CustomAttribute> attributes, string number)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByNumberAsync(number);
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute, Is.EqualTo(attributes.Single(x => x.Number == number)));
        }

        private static readonly object[] s_attributeGetByNumberFailedCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                },
                "GG"
            }
        };

        [TestCaseSource(nameof(s_attributeGetByNumberFailedCase))]
        public async Task GetByNumberNotFoundAsync(List<CustomAttribute> attributes, string number)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByNumberAsync(number);
            Assert.That(attribute, Is.Null);
        }

        private static readonly object[] s_attributeInsertSuccessCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                },
                new CreateCustomAttributeDto
                {
                    Number = "HEIGHT",
                    Name = "Height"
                },
                "creater"
            }
        };

        [TestCaseSource(nameof(s_attributeInsertSuccessCase))]
        public async Task InsertSuccessAsync(List<CustomAttribute> attributes, CreateCustomAttributeDto dto, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute attribute = await dao.InsertAsync(dto, creater);
            Assert.Multiple(() =>
            {
                Assert.That(attribute.Number, Is.EqualTo(dto.Number));
                Assert.That(attribute.Name, Is.EqualTo(dto.Name));
            });
        }

        private static readonly object[] s_attributeInsertFailedCase =
        {
            new object[]
            {
                new List<CustomAttribute>
                {
                    new CustomAttribute
                    {
                        Id = 1,
                        Number = "WEIGHT",
                        Name = "Weight"
                    },
                },
                new CreateCustomAttributeDto
                {
                    Number = "WEIGHT",
                    Name = "Weight"
                },
                "creater"
            }
        };

        [TestCaseSource(nameof(s_attributeInsertFailedCase))]
        public void InsertFailedAsync(List<CustomAttribute> attributes, CreateCustomAttributeDto dto, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.InsertAsync(dto, creater));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbInsertDuplicate));
        }

        private static readonly object[] s_attributeUpdateCase =
        {
            new object[]
            {
                new CustomAttribute
                {
                    Id = 1,
                    Number = "WEIGHT",
                    Name = "Weight",
                    UpdateUser = "Haha"
                },
                "updater"
            }
        };

        [TestCaseSource(nameof(s_attributeUpdateCase))]
        public async Task UpdateAsync(CustomAttribute entity, string updater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            CustomAttributeDao dao = new(mock.Object);
            await dao.UpdateAsync(entity, updater);
            Assert.That(updater, Is.EqualTo(entity.UpdateUser));
        }
    }
}
