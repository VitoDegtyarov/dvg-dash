using dvg.Core.Enums;

namespace dvg.DTO
{
    public class DesignerDTO
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DesignerPosition Position { get; set; }

    }
}
