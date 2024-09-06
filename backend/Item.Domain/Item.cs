using Rus.Base.Domain;

namespace Item.Domain;

public class Item : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public List<ItemPicture>? ItemPictures { get; set; }
    public List<ItemTag>? ItemTags { get; set; }
}