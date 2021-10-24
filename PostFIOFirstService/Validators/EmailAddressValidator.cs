using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApp.PostFIOFirstService.Validators
{
    public class EmailAddressValidator : AbstractValidator<string>
    {
        public EmailAddressValidator()
        {
            RuleFor(emailAddress => emailAddress)
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
    }
}
