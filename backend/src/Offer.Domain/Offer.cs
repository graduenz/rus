using Rus.Base.Domain;

namespace Offer.Domain;

public class Offer : BaseEntity
{
    public long ItemId { get; set; }
    public long AdvertiserId { get; set; }
    // TODO: Add more info (price, due date, info, etc.)
}