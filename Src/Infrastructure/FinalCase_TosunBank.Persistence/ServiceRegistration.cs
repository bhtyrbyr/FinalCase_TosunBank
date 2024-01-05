using FinalCase_TosunBank.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalCase_TosunBank.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TosunBankDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString: connectionString, b => b.MigrationsAssembly("FinalCase_TosunBank.WebApi"));
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        return services;
    }
}
