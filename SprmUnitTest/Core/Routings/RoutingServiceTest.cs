using System.Text.Json;
using Moq;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Parts;
using SprmApi.Core.Routings;
using SprmApi.Core.Routings.Dto;
using SprmApi.Core.RoutingUsages;
using SprmApi.MiddleWares;

namespace SprmUnitTest.Core.Routings
{
    internal class RoutingServiceTest
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

        private static readonly object[] s_routingInsertSuccessCase =
        {
            new object[]
            {
                new CreateRoutingDto
                {
                    PartId = 1,
                    Name = "1",
                },
                new Part
                {
                    Id = 1,
                },
                new Routing
                {
                    Id = 1,
                    PartId = 1,
                    Name = "1",
                    Remarks = "Test",
                },
                new RoutingVersion
                {
                    Id = 1,
                    MasterId = 1,
                    Version = 1,
                    IsLatest = false,
                    IsDraft = true,
                    CustomValues = JsonSerializer.SerializeToDocument(new Dictionary<string, string>()),
                }
            }
        };

        [TestCaseSource(nameof(s_routingInsertSuccessCase))]
        public async Task InsertSuccessTestAsync(
            CreateRoutingDto dto,
            Part part,
            Routing newRouting,
            RoutingVersion newVersion
        )
        {
            Mock<IPartDao> partDaoMock = new(MockBehavior.Strict);
            partDaoMock
                .Setup(x => x.GetByIdAsync(dto.PartId))
                .ReturnsAsync(part);

            Mock<IRoutingDao> routingDaoMock = new(MockBehavior.Strict);
            CreateRoutingDto? inputDto = null;
            string? routingCreater = null;
            routingDaoMock
                .Setup(x => x.InsertAsync(It.IsAny<CreateRoutingDto>(), It.IsAny<string>()))
                .Callback<CreateRoutingDto, string>((createDto, creater) =>
                {
                    inputDto = createDto;
                    routingCreater = creater;
                })
                .ReturnsAsync(newRouting);

            Mock<IRoutingVersionDao> routingVersionDaoMock = new(MockBehavior.Strict);
            RoutingVersion? inputVersion = null;
            string? routingVersionCreater = null;
            routingVersionDaoMock
                .Setup(x => x.InsertAsync(It.IsAny<RoutingVersion>(), It.IsAny<string>()))
                .Callback<RoutingVersion, string>((routeVersion, creater) =>
                {
                    inputVersion = routeVersion;
                    routingVersionCreater = creater;
                })
                .ReturnsAsync(newVersion);

            Mock<IRoutingUsageDao> usageDaoMock = new(MockBehavior.Strict);

            RoutingService service = new(
                routingDaoMock.Object,
                routingVersionDaoMock.Object,
                usageDaoMock.Object,
                partDaoMock.Object,
                _headerData);
            RoutingDto result = await service.InsertAsync(dto);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(inputDto, Is.Not.Null);
                Assert.That(inputVersion, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(routingCreater, Is.Not.Null);
                Assert.That(routingVersionCreater, Is.Not.Null);
                Assert.That(routingCreater, Is.EqualTo(_headerData.JWTPayload.Subject));
                Assert.That(routingVersionCreater, Is.EqualTo(_headerData.JWTPayload.Subject));
                Assert.That(inputDto.PartId, Is.EqualTo(dto.PartId));
                Assert.That(inputDto.Name, Is.EqualTo(dto.Name));
                Assert.That(inputVersion.MasterId, Is.EqualTo(newVersion.MasterId));
                Assert.That(result.Id, Is.EqualTo(newRouting.Id));
                Assert.That(result.Name, Is.EqualTo(dto.Name));
                Assert.That(result.Version.Id, Is.EqualTo(newVersion.Id));
            });
        }

        private static readonly object[] s_routingInsertFailedPartNotExistCase =
        {
            new object[]
            {
                new CreateRoutingDto
                {
                    PartId = 1,
                    Name = "1",
                },
            }
        };

        [TestCaseSource(nameof(s_routingInsertFailedPartNotExistCase))]
        public void InsertPartNotExist(CreateRoutingDto dto)
        {
            Mock<IPartDao> partDaoMock = new(MockBehavior.Strict);
            partDaoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(value: null);

            Mock<IRoutingDao> routingDaoMock = new(MockBehavior.Strict);
            Mock<IRoutingVersionDao> routingVersionDaoMock = new(MockBehavior.Strict);
            Mock<IRoutingUsageDao> usageDaoMock = new(MockBehavior.Strict);

            RoutingService service = new(
                routingDaoMock.Object,
                routingVersionDaoMock.Object,
                usageDaoMock.Object,
                partDaoMock.Object,
                _headerData);
            SprmException? ex = Assert.ThrowsAsync<SprmException>(() => service.InsertAsync(dto));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Code, Is.EqualTo(ErrorCode.DbDataNotFound));
        }
    }
}
