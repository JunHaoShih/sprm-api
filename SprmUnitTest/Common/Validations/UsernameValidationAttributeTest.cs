using System.ComponentModel.DataAnnotations;
using SprmApi.Common.Validations;

namespace SprmUnitTest.Common.Validations
{
    internal class UsernameValidationAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_validateSuccessCase =
        {
            new object[]
            {
                "validName"
            },
            new object[]
            {
                "__validName"
            },
            new object[]
            {
                "__validName__"
            },
            new object[]
            {
                "validName__"
            },
            new object[]
            {
                "__valid___Name__"
            },
            new object[]
            {
                "______"
            },
        };

        [TestCaseSource(nameof(s_validateSuccessCase))]
        public void ValidateSuccess(string username)
        {
            ValidationContext context = new(username);
            UsernameValidationAttribute attribute = new();
            attribute.Validate(username, context);
            Assert.Pass(username);
        }

        private static readonly object[] s_validateNonStringCase =
        {
            new object[]
            {
                123
            },
            new object[]
            {
                false
            },
        };

        [TestCaseSource(nameof(s_validateNonStringCase))]
        public void ValidateNonString(object badData)
        {
            ValidationContext context = new(badData);
            UsernameValidationAttribute attribute = new();
            ValidationException? ex = Assert.Throws<ValidationException>(() => attribute.Validate(badData, context));
            Assert.That(ex, Is.Not.Null);
            Assert.Pass(ex.Message);
        }

        private static readonly object[] s_validateFailedCase =
        {
            new object[]
            {
                "short"
            },
            new object[]
            {
                "TooLooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooog"
            },
            new object[]
            {
                "no$InvalidChar"
            },
            new object[]
            {
                "no-InvalidChar"
            },
            new object[]
            {
                "no invalid char"
            },
            new object[]
            {
                string.Empty
            },
        };

        [TestCaseSource(nameof(s_validateFailedCase))]
        public void ValidateFailed(string badData)
        {
            ValidationContext context = new(badData);
            UsernameValidationAttribute attribute = new();
            ValidationException? ex = Assert.Throws<ValidationException>(() => attribute.Validate(badData, context));
            Assert.That(ex, Is.Not.Null);
            Assert.Pass(ex.Message);
        }
    }
}
