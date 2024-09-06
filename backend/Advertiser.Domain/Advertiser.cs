using Rus.Base.Domain;

namespace Advertiser.Domain;

public class Advertiser : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? ContactInstructions { get; set; }
}