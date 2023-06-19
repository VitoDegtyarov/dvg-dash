using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dvg.Data.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}