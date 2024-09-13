using Rus.Base.Domain;

namespace Item.Domain;

public class ItemPicture : BaseEntity
{
    public long ItemId { get; set; }
    public string? Url { get; set; }
    
    public Item? Item { get; set; }
}