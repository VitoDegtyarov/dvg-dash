using dvg.Core.Enums;

namespace dvg.Data.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }

        public DateTime Term { get; set; }
        public decimal Cost { get; set; }

        public ProjectStatus Status { get; set; }

        public ICollection<Designer> Attendees { get; set; }
        public ICollection<CustomTask> Tasks { get; set; }
    }
}