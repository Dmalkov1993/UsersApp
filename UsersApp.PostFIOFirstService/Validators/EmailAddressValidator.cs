using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;

namespace UsersApp.PostFIOFirstService.Validators
{
    public class EmailAddressValidator : AbstractValidator<string>
    {
        public EmailAddressValidator()
        {
            RuleFor(emailAddress => emailAddress)
                .NotNull()
                .Must(emailAddress => IsValidEmail(emailAddress))
                .WithName("emailAddress");
        }

        private bool IsValidEmail(string emailAddress)
        {
            if (emailAddress.Trim().EndsWith("."))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(emailAddress);
                return addr.Address == emailAddress;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Переопределение метода для того, чтобы в валидатор можно было передать null.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ValidationResult Validate(ValidationContext<string> context)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure("emailAddress", "Object cannot be null") })
                : base.Validate(context);
        }
    }
}
