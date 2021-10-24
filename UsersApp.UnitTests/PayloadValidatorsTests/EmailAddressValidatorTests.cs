using NUnit.Framework;
using UsersApp.PostFIOFirstService.Validators;

namespace UsersApp.UnitTests.PayloadValidatorsTests
{
    [TestFixture]
    public class EmailAddressValidatorTests : BaseValidatorTests
    {
        private EmailAddressValidator emailAddressValidator;

        [SetUp]
        public void Setup()
        {
            emailAddressValidator = new EmailAddressValidator();
        }

        [TestCase(null, false)]
        [TestCase("test", false)]
        [TestCase("test@", false)]
        [TestCase("test@uf.", false)]
        [TestCase("test@uf.r", true)]
        [TestCase("@uf.r", false)]
        [TestCase("uf.r", false)]
        [TestCase("test@uf.ru", true)]
        [TestCase("test@uf.yourip.ru", true)]
        public void TestEmailAddressValidation(string email, bool expectedResult)
        {
            // Act
            var actionResult = emailAddressValidator.Validate(email);

            // Assert
            AssertByExpectedResult(actionResult, "emailAddress", expectedResult);
        }
    }
}
