using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinalCase_TosunBank.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assm);
        services.AddMediatR(assm);
        return services;
    }
}
