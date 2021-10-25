using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("id", Order = 0)]
        public long Id { get; set; }
    }
}
