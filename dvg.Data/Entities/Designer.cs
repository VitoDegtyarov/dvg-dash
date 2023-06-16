using dvg.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvg.Data.Entities
{
    public class Designer : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public DesignerPosition Position { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
