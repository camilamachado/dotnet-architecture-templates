using MeuProjeto.Api.Endpoints;
using MeuProjeto.Api.Middlewares;
using MeuProjeto.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Api.Extensions;

public static class AppConfigureExtensions
{
    public static async Task Configure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                c.RoutePrefix = "";
            });

            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<MeuProjetoDbContext>();
            if (db.Database.IsRelational())
            {
                db.Database.Migrate();
            }
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapOrdersEndpoints();

        app.MapHealthChecks("/health");
        app.MapHealthChecks("/ready");
    }
}
