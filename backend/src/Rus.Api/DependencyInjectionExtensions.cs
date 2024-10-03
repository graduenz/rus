using Advertiser.Application;
using Advertiser.Application.Advertiser;
using Advertiser.Infrastructure;
using Rus.Base.Application.Interfaces;
using Rus.Base.Infrastructure;

namespace Rus.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection
        AddApiInfrastructure(this IServiceCollection services, IConfiguration configuration) => services
        .AddApiServices()
        .AddBaseInfrastructure()
        .AddModules(configuration)
        .AddMediatR()
        .AddAutoMapper();

    private static IServiceCollection AddApiServices(this IServiceCollection services) => services
        .AddHttpContextAccessor()
        .AddScoped<ICurrentUserService, CurrentUserServiceImpl>();
    
    private static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration) => services
        .AddAdvertiserInfrastructure(configuration);
    
    private static IServiceCollection AddMediatR(this IServiceCollection services) => services
        .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(CreateAdvertiserCommand).Assembly)
        );

    private static IServiceCollection AddAutoMapper(this IServiceCollection services) => services
        .AddAutoMapper(
            typeof(Advertiser.Application.MappingProfile).Assembly
        );
}