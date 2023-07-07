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

        private static readonly object[] s_attribureDeleteSuccessCase =
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

        [TestCaseSource(nameof(s_attribureDeleteSuccessCase))]
        public async Task DeleteSuccessAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            await dao.DeleteAsync(id);
            Assert.Pass();
        }

        private static readonly object[] s_attribureDeleteFailedCase =
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

        [TestCaseSource(nameof(s_attribureDeleteFailedCase))]
        public void DeleteFailedAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.DeleteAsync(id));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        [TestCaseSource(nameof(s_attribureDeleteSuccessCase))]
        public async Task GetByIdFoundAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByIdAsync(id);
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute, Is.EqualTo(attributes.Single(x => x.Id == id)));
        }

        [TestCaseSource(nameof(s_attribureDeleteFailedCase))]
        public async Task GetByIdNotFoundAsync(List<CustomAttribute> attributes, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByIdAsync(id);
            Assert.That(attribute, Is.Null);
        }

        private static readonly object[] s_attribureGetByNumberSuccessCase =
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

        [TestCaseSource(nameof(s_attribureGetByNumberSuccessCase))]
        public async Task GetByNumberFoundAsync(List<CustomAttribute> attributes, string number)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByNumberAsync(number);
            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute, Is.EqualTo(attributes.Single(x => x.Number == number)));
        }

        private static readonly object[] s_attribureGetByNumberFailedCase =
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

        [TestCaseSource(nameof(s_attribureGetByNumberFailedCase))]
        public async Task GetByNumberNotFoundAsync(List<CustomAttribute> attributes, string number)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            CustomAttribute? attribute = await dao.GetByNumberAsync(number);
            Assert.That(attribute, Is.Null);
        }

        private static readonly object[] s_attribureInsertSuccessCase =
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

        [TestCaseSource(nameof(s_attribureInsertSuccessCase))]
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

        private static readonly object[] s_attribureInsertFailedCase =
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

        [TestCaseSource(nameof(s_attribureInsertFailedCase))]
        public void InsertFailedAsync(List<CustomAttribute> attributes, CreateCustomAttributeDto dto, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.CustomAttributes).Returns(attributes.BuildMock().BuildMockDbSet().Object);
            CustomAttributeDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.InsertAsync(dto, creater));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbInsertDuplicate));
        }

        private static readonly object[] s_attribureUpdateCase =
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

        [TestCaseSource(nameof(s_attribureUpdateCase))]
        public async Task UpdateAsync(CustomAttribute entity, string updater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            CustomAttributeDao dao = new(mock.Object);
            await dao.UpdateAsync(entity, updater);
            Assert.That(updater, Is.EqualTo(entity.UpdateUser));
        }
    }
}
