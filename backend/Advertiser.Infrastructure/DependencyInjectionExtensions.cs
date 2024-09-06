using Advertiser.Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rus.Base.Application.Interfaces;

namespace Advertiser.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection
        AddAdvertiserInfrastructure(this IServiceCollection services, IConfiguration configuration) => services
        .AddDbContext<AdvertiserDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Advertiser"),
                b => b.MigrationsAssembly("Advertiser.Migrations"))
        )
        .AddScoped<IBaseDbContext>(provider =>
            provider.GetService<AdvertiserDbContext>() ?? throw new InvalidOperationException($"Couldn't resolve {nameof(AdvertiserDbContext)}"))
        .AddValidatorsFromAssemblyContaining(typeof(AdvertiserDtoValidator));
}