using dvg.Core.Enums;

namespace dvg.Dto
{
    public class DesignerDto
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DesignerPosition Position { get; set; }

    }
}
