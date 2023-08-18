using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.Customs;
using SprmApi.Core.ObjectTypes;
using SprmApi.EFs;

namespace SprmUnitTest.Core.Customs
{
    internal class AttributeLinkDaoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_linksDeleteSuccessCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                    new AttributeLink
                    {
                        Id = 2,
                        ObjectTypeId = 1,
                        AttributeId = 2,
                    },
                },
                1
            }
        };

        [TestCaseSource(nameof(s_linksDeleteSuccessCase))]
        public async Task DeleteSuccessAsync(List<AttributeLink> links, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            await dao.DeleteAsync(id);
            Assert.Pass();
        }

        private static readonly object[] s_linksDeleteFailedCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                },
                2
            }
        };

        [TestCaseSource(nameof(s_linksDeleteFailedCase))]
        public void DeleteFailed(List<AttributeLink> links, long id)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.DeleteAsync(id));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }

        private static readonly object[] s_linksGetByObjectTypeAndAttributeIdSuccessCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                    new AttributeLink
                    {
                        Id = 2,
                        ObjectTypeId = 1,
                        AttributeId = 2,
                    },
                    new AttributeLink
                    {
                        Id = 3,
                        ObjectTypeId = 2,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.PartVersion,
                1,
            }
        };

        [TestCaseSource(nameof(s_linksGetByObjectTypeAndAttributeIdSuccessCase))]
        public async Task GetByObjectTypeAndAttributeIdSuccess(List<AttributeLink> links, SprmObjectType objectType, long attributeId)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            AttributeLink? targetLink = await dao.Get(objectType, attributeId);
            AttributeLink expectedLink = links.Single(link => link.Id == (long)objectType);
            Assert.That(targetLink, Is.Not.Null);
            Assert.That(targetLink, Is.EqualTo(expectedLink));
        }

        private static readonly object[] s_linksGetByObjectTypeAndAttributeIdFailedCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                    new AttributeLink
                    {
                        Id = 2,
                        ObjectTypeId = 1,
                        AttributeId = 2,
                    },
                    new AttributeLink
                    {
                        Id = 3,
                        ObjectTypeId = 2,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.PartVersion,
                3,
            }
        };

        [TestCaseSource(nameof(s_linksGetByObjectTypeAndAttributeIdFailedCase))]
        public async Task GetByObjectTypeAndAttributeIdFailedAsync(List<AttributeLink> links, SprmObjectType objectType, long attributeId)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            AttributeLink? targetLink = await dao.Get(objectType, attributeId);
            Assert.That(targetLink, Is.Null);
        }

        private static readonly object[] s_linksGetByObjectTypeCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                    new AttributeLink
                    {
                        Id = 2,
                        ObjectTypeId = 1,
                        AttributeId = 2,
                    },
                    new AttributeLink
                    {
                        Id = 3,
                        ObjectTypeId = 2,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.PartVersion,
            },
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                    new AttributeLink
                    {
                        Id = 2,
                        ObjectTypeId = 1,
                        AttributeId = 2,
                    },
                    new AttributeLink
                    {
                        Id = 3,
                        ObjectTypeId = 2,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.Routing,
            }
        };

        [TestCaseSource(nameof(s_linksGetByObjectTypeCase))]
        public async Task GetByObjectTypeAsync(List<AttributeLink> links, SprmObjectType objectType)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            IEnumerable<AttributeLink> targetLinks = await dao.GetByObjectTypeAsync(objectType);
            IEnumerable<AttributeLink> expectedLinks = links.Where(link => link.ObjectTypeId == (long)objectType);
            Assert.That(targetLinks.Count(), Is.EqualTo(expectedLinks.Count()));
        }

        private static readonly object[] s_insertSuccessCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.PartVersion,
                3,
                "creater"
            },
        };

        [TestCaseSource(nameof(s_insertSuccessCase))]
        public async Task InsertSuccessAsync(List<AttributeLink> links, SprmObjectType objectType, long attributeId, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            AttributeLink newLink = await dao.InsertAsync(objectType, attributeId, creater);
            Assert.Multiple(() =>
            {
                Assert.That(newLink.ObjectTypeId, Is.EqualTo((long)objectType));
                Assert.That(newLink.AttributeId, Is.EqualTo(attributeId));
                Assert.That(newLink.CreateUser, Is.EqualTo(creater));
            });
        }

        private static readonly object[] s_insertFailedCase =
        {
            new object[]
            {
                new List<AttributeLink>
                {
                    new AttributeLink
                    {
                        Id = 1,
                        ObjectTypeId = 1,
                        AttributeId = 1,
                    },
                },
                SprmObjectType.PartVersion,
                1,
                "creater"
            },
        };

        [TestCaseSource(nameof(s_insertFailedCase))]
        public void InsertFailed(List<AttributeLink> links, SprmObjectType objectType, long attributeId, string creater)
        {
            Mock<SprmContext> mock = new(new DbContextOptions<SprmContext>());
            mock.Setup(x => x.AttributeLinks)
                .Returns(links.BuildMock().BuildMockDbSet().Object);
            AttributeLinkDao dao = new(mock.Object);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => dao.InsertAsync(objectType, attributeId, creater));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbInsertDuplicate));
        }
    }
}
