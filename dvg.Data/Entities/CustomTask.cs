using dvg.Core.Enums;

namespace dvg.Data.Entities
{
    public class CustomTask : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Term { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public ICollection<Designer> Attendees { get; set; }


    }
}