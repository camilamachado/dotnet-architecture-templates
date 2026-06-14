using FluentValidation;
using MediatR;
using MeuProjeto.Application;
using MeuProjeto.Domain;
using MeuProjeto.Domain.Repositories.Orders;
using MeuProjeto.Infrastructure.Database;
using MeuProjeto.Infrastructure.Repositories.Orders;
using MeuProjeto.SharedKernel.Behaviors;
using MeuProjeto.SharedKernel.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuProjeto.IoC;

public static class AppServiceCollectionExtensions
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<JwtSettings>().Bind(configuration.GetSection("JwtSettings"))
                .ValidateDataAnnotations()
                .ValidateOnStart();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(
                typeof(IDomainEntryPoint).Assembly,
                typeof(IApplicationAssembly).Assembly,
                typeof(ValidationBehavior<,>).Assembly)
        );

        services.AddValidatorsFromAssemblyContaining<IApplicationAssembly>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddDbContext<MeuProjetoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"),
                npgsql => npgsql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorCodesToAdd: null)));

        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Services

    }
}
