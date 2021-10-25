using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.DAL.Entities
{
    [Table("Users", Schema = ProjectDbSchemaName.UsersApp)]
    public class User : BaseEntity
    {
        /// <summary>
        /// Организация, к которой привязан пользователь.
        /// </summary>
        [Column("Organization")]
        public Organization Organization { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Surname")]
        public string Surname { get; set; }

        [Column("Patronymic")]
        public string Patronymic { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
