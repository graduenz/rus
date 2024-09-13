using Microsoft.EntityFrameworkCore;
using Rus.Base.Application.Interfaces;

namespace Advertiser.Infrastructure;

public class AdvertiserDbContext : DbContext, IBaseDbContext
{
    public AdvertiserDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Domain.Advertiser> Advertisers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdvertiserEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}