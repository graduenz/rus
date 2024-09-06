using Rus.Base.Domain;

namespace Item.Domain;

public class ItemTag : BaseEntity
{
    public long ItemId { get; set; }
    public long TagId { get; set; }
    
    public Item? Item { get; set; }
}