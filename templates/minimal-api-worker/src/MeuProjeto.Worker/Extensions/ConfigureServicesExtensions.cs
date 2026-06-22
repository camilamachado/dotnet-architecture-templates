using MeuProjeto.IoC;
using MeuProjeto.Infrastructure.Messaging;
using MeuProjeto.Worker.Consumers;

namespace MeuProjeto.Worker.Extensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureWorkerDependencies(configuration);

        services.AddMassTransitRabbitMq(configuration, x =>
        {
            x.AddConsumer<OrderPlacedConsumer>();
        });

        return services;
    }
}
