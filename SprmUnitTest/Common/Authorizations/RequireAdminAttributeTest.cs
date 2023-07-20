using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using SprmApi.MiddleWares;
using static SprmApi.Common.Authorizations.RequireAdminAttribute;

namespace SprmUnitTest.Common.Authorizations
{
    internal class RequireAdminAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_adminJwtCase =
        {
            new object[]
            {
                new HeaderData
                {
                    Bearer = string.Empty,
                    JWTPayload = new SprmApi.Core.Auth.JwtPayload
                    {
                        IsAdmin = false,
                    }
                }
            }
        };

        [TestCaseSource(nameof(s_adminJwtCase))]
        public void TestAdmin(HeaderData headerData)
        {
            RequireAdminBaseAttribute baseAttribute = new(headerData);
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
    }
}
