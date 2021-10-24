using System.Linq;
using FluentAssertions;
using FluentValidation.Results;

namespace UsersApp.UnitTests.PayloadValidatorsTests
{
    public abstract class BaseValidatorTests
    {
        protected static void AssertByExpectedResult(ValidationResult actionResult, string text, bool expectedResult)
        {
            if (!expectedResult)
            {
                actionResult.Errors.Select(failure => failure.PropertyName).Should().Contain(text);
            }
            else
            {
                actionResult.Errors.Select(failure => failure.PropertyName).Should().NotContain(text);
            }
        }
    }
}