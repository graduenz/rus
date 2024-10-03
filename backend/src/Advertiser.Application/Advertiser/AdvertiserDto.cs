using Rus.Base.Application.Dto;

namespace Advertiser.Application.Advertiser;

public class AdvertiserDto : BaseDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? ContactInstructions { get; set; }
}