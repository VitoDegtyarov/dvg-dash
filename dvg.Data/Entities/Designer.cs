using dvg.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dvg.Data.Entities
{
    public class Designer : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DesignerPosition Position { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
