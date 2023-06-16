using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dvg.Data.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string LastName { get; set; }

        public int PhoneNumber { get; set; }
    }
}