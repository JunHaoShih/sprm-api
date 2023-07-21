using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SprmApi.MiddleWares;
using static SprmApi.Common.Authorizations.RequirePermissionAttribute;
using SprmApi.Core.ObjectTypes;
using SprmApi.Common.Authorizations;
using SprmApi.Core.Permissions.Dto;

namespace SprmUnitTest.Common.Authorizations
{
    internal class RequirePermissionAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_noPermissionCase =
        {
            new object[]
            {
                new HeaderData
                {
                    Bearer = string.Empty,
                    JWTPayload = new SprmApi.Core.Auth.JwtAccessPayload
                    {
                        IsAdmin = false,
                        Permissions = new List<PermissionDto>
                        {
                            new PermissionDto
                            {
                                ObjectType = SprmObjectType.PartVersion,
                            }
                        }
                    }
                },
                SprmObjectType.PartVersion,
                new List<Crud>
                {
                    Crud.Create
                }
            }
        };

        [TestCaseSource(nameof(s_noPermissionCase))]
        public void TestNoPermission(HeaderData headerData, SprmObjectType objectType, List<Crud> cruds)
        {
            RequirePermissionBaseAttribute baseAttribute = new(headerData, objectType, cruds.ToArray());
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock
                .Setup(a => a.Request.Headers["Authorization"])
                .Returns("Not importaant");
            ActionContext fakeActionContext = new ActionContext(
                httpContextMock.Object,
                new Microsoft.AspNetCore.Routing.RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );
            AuthorizationFilterContext fakeAuthFilterContext = new(
                fakeActionContext,
                new List<IFilterMetadata>()
            );
            baseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(403));
        }

        private static readonly object[] s_adminCase =
        {
            new object[]
            {
                new HeaderData
                {
                    Bearer = string.Empty,
                    JWTPayload = new SprmApi.Core.Auth.JwtAccessPayload
                    {
                        IsAdmin = true,
                    }
                },
                SprmObjectType.PartVersion,
                new List<Crud>
                {
                    Crud.Create
                }
            }
        };

        [TestCaseSource(nameof(s_adminCase))]
        public void TestAdmin(HeaderData headerData, SprmObjectType objectType, List<Crud> cruds)
        {
            RequirePermissionBaseAttribute baseAttribute = new(headerData, objectType, cruds.ToArray());
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock
                .Setup(a => a.Request.Headers["Authorization"])
                .Returns("Not importaant");
            ActionContext fakeActionContext = new ActionContext(
                httpContextMock.Object,
                new Microsoft.AspNetCore.Routing.RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );
            AuthorizationFilterContext fakeAuthFilterContext = new(
                fakeActionContext,
                new List<IFilterMetadata>()
            );
            baseAttribute.OnAuthorization(fakeAuthFilterContext);
            ObjectResult? result = fakeAuthFilterContext.Result as ObjectResult;
            Assert.That(result, Is.Null);
        }
    }
}
