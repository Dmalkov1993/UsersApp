using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.DAL.Entities
{
    [Table("Organizations", Schema = ProjectDbSchemaName.UsersApp)]
    public class Organization : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
