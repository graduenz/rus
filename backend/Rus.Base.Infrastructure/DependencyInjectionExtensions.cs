using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rus.Base.Application.Behaviors;
using Rus.Base.Application.Interfaces;
using Rus.Base.Infrastructure.Adapters;

namespace Rus.Base.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddBaseInfrastructure(this IServiceCollection services) => services
        .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>))
        .AddAdapters();

    private static IServiceCollection AddAdapters(this IServiceCollection services) => services
        .AddScoped<IFilterAdapter, FilterAdapter>()
        .AddScoped<ISortAdapter, SortAdapter>();
}