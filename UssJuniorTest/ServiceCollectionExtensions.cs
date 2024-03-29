using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Infrastructure.Services;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest;

public static class ServiceCollectionExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IStore, InMemoryStore>();
        services.AddScoped<IDriveService, DriveInfoService>();
        
        services.AddScoped<IRepository<Car>, CarRepository>();
        services.AddScoped<IRepository<Person>, PersonRepository>();
        services.AddScoped<IRepository<DriveLog>, DriveLogsRepository>();
    }
}