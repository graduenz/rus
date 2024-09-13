using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rus.Base.Infrastructure;

namespace Advertiser.Infrastructure;

public class AdvertiserEntityConfiguration : BaseEntityTypeConfiguration<Domain.Advertiser>
{
    public override void Configure(EntityTypeBuilder<Domain.Advertiser> builder)
    {
        base.Configure(builder);
        
        builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(2000).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(320);
        builder.Property(m => m.Phone).HasMaxLength(20);
        builder.Property(m => m.ContactInstructions).HasMaxLength(200);
    }
}