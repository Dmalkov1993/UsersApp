using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApp.PostFIOFirstService.RequestPayloads
{
    public class AcceptUserDataRequestPayload : IRequest<IActionResult>
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
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
