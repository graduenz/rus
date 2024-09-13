namespace Rus.Base.Application.Dto;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
}