using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UsersApp.Infrastructure.RequestPayloads
{
    public class AcceptUserDataRequestPayload : IRequest<IActionResult>
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [DefaultValue("Ivan")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DefaultValue("Ivanov")]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DefaultValue("Васильевич")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [DefaultValue("9991113344")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [DefaultValue("Ivanov@ya.ru")]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                $"{nameof(Surname)}: {Surname}, " +
                $"{nameof(Patronymic)}: {Patronymic}, " +
                $"{nameof(PhoneNumber)}: {PhoneNumber}, " +
                $"{nameof(Email)}: {Email}";
        }
    }
}
