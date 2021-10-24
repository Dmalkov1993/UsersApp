using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UsersApp.PostFIOFirstService.RequestPayloads;

namespace UsersApp.PostFIOFirstService.Validators
{
    public class AcceptUserDataValidator : AbstractValidator<AcceptUserDataRequestPayload>
    {
        /// <summary>
        /// Согласно заданию, заполнено должно быть всё, кроме отчества.
        /// Моб. телефон и email - стандартная валидация для указанных типов данных.
        /// </summary>
        public AcceptUserDataValidator(IValidator<string> emailAddressValidator)
        {
            // Для имени и фамилии установим мин. длину - 2, и не пустое.
            RuleFor(userData => userData.Name)
                .NotNull()
                .MinimumLength(2)
                .WithName($"Имя ({nameof(AcceptUserDataRequestPayload.Name)})");

            // Для имени и фамилии установим мин. длину - 2, и не пустое.
            RuleFor(userData => userData.Surname)
                .NotNull()
                .MinimumLength(2)
                .WithName($"Фамилия ({nameof(AcceptUserDataRequestPayload.Surname)})");

            // Номер может вводиться начиная с 9-ки, + ещё 9 цифр (было придумано для упрощения).
            var phoneNumberPattern = "^9[0-9]{9}$";
            RuleFor(userData => userData.PhoneNumber)
                .NotNull()
                .Must(phoneNumber => Regex.IsMatch(phoneNumber, phoneNumberPattern))
                .WithMessage($"Моб. телефон ({nameof(AcceptUserDataRequestPayload.PhoneNumber)}), шаблон: {phoneNumberPattern}");

            // Валидация email вынесена в отдельный валидатор,
            // так как способов валидации Email-ов может быть несколько (можно было и просто через регулярку).
            RuleFor(userData => userData.Email)
                .NotNull()
                .Must(email => emailAddressValidator.Validate(email).IsValid)
                .WithMessage($"Эл. почта ({nameof(AcceptUserDataRequestPayload.Email)})");
        }
    }
}
