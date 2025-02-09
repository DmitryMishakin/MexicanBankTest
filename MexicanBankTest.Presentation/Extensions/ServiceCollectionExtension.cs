using MexicanBankTest.BLL.Abstractions;
using MexicanBankTest.BLL.Services;
using MexicanBankTest.DAL;
using MexicanBankTest.DAL.Abstractions;
using MexicanBankTest.DAL.Repositories;

namespace MexicanBankTest.Presentation.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDbServices(this IServiceCollection services)
    {
        services.AddDbContext<TestDbContext>();
        services.AddScoped<IValueRepository, ValueRepository>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IValueRepository, ValueRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IValueService, ValueService>();
        return services;
    }
}