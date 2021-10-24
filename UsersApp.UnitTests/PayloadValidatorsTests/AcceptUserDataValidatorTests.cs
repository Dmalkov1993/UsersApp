using NUnit.Framework;
using UsersApp.PostFIOFirstService.RequestPayloads;
using UsersApp.PostFIOFirstService.Validators;

namespace UsersApp.UnitTests.PayloadValidatorsTests
{
    [TestFixture]
    public class AcceptUserDataValidatorTests : BaseValidatorTests
    {
        private AcceptUserDataValidator acceptUserDataValidator;

        [SetUp]
        public void Setup()
        {
            acceptUserDataValidator = new AcceptUserDataValidator(new EmailAddressValidator());
        }

        [TestCase(null, false)]
        [TestCase("r", false)] // меньше двух букв в имени
        [TestCase("кк", true)]
        [TestCase("siouhfsshgsg", true)] // Длинное имя
        public void TestValidationByName(string name, bool expectedResult)
        {
            // Arrange
            var payload = new AcceptUserDataRequestPayload
            {
                Name = name,
                Surname = "Ivanov",
                PhoneNumber = "9091112233",
                Email = "test@gmail.com"
            };

            // Act
            var actionResult = acceptUserDataValidator.Validate(payload);

            // Assert
            AssertByExpectedResult(actionResult, $"Имя ({nameof(AcceptUserDataRequestPayload.Name)})", expectedResult);
        }

        [TestCase(null, false)]
        [TestCase("r", false)] // меньше двух букв в фамилии
        [TestCase("кк", true)]
        [TestCase("siouhfsshgsg", true)] // Длинная фамилия
        public void TestValidationBySurname(string surname, bool expectedResult)
        {
            // Arrange
            var payload = new AcceptUserDataRequestPayload
            {
                Name = "Ivan",
                Surname = surname,
                PhoneNumber = "9091112233",
                Email = "test@gmail.com"
            };

            // Act
            var actionResult = acceptUserDataValidator.Validate(payload);

            // Assert
            AssertByExpectedResult(actionResult, $"Фамилия ({nameof(AcceptUserDataRequestPayload.Surname)})", expectedResult);
        }

        [TestCase(null, false)]
        [TestCase("цшгпашцфпацкапщрцщк", false)] // пришло непонятно что в номере телефона
        [TestCase("1091112233", false)] // Не начинается с 9-ки
        [TestCase("999999999", false)] // Меньше 9-ти цифр, не считая начальной 9-ки
        [TestCase("99999999911", false)] // Больше 9-ти цифр, не считая начальной 9-ки
        [TestCase("9091112233", true)]
        [TestCase("9999999999", true)]
        public void TestValidationByPhoneNumber(string phoneNumner, bool expectedResult)
        {
            // Arrange
            var payload = new AcceptUserDataRequestPayload
            {
                Name = "Ivan",
                Surname = "Ivanov",
                PhoneNumber = phoneNumner,
                Email = "test@gmail.com"
            };

            // Act
            var actionResult = acceptUserDataValidator.Validate(payload);

            // Assert
            AssertByExpectedResult(actionResult, "Моб. телефон (" + nameof(AcceptUserDataRequestPayload.PhoneNumber) +", шаблон: ^9[0-9]{9}$)", expectedResult);
        }
    }
}
