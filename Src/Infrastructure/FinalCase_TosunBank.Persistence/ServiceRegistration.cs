using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Persistence.Context;
using FinalCase_TosunBank.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalCase_TosunBank.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TosunBankDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString: connectionString);
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddIdentity<BasePerson, IdentityRole>().AddEntityFrameworkStores<TosunBankDbContext>().AddDefaultTokenProviders();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountStatementRepository, AccountStatementRepository>();
        services.AddScoped<IAuthorisedRepository, AuthorisedRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<INewCustomerAccountOpeningRequestRepository, NewCustomerAccountOpeningRequestRepository>();
        services.AddScoped<INewBankAccountOpeningRequestRepository, NewBankAccountOpeningRequestRepository>();
        services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        return services;
    }
}
