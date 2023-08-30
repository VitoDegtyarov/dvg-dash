using dvg.Core.Enums;

namespace dvg.Core.UpdateModels;

public class DesignerUpdateModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DesignerPosition? Position { get; set; }

    public bool IsEmpty()
    {
        return FirstName == null && LastName == null && PhoneNumber == null && Position == null;
    }
}