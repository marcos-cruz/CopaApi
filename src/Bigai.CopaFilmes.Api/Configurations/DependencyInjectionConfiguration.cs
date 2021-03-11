using Bigai.CopaFilmes.Api.Configurations.Swagger;
using Bigai.CopaFilmes.Domain.Core.Filmes.Interfaces;
using Bigai.CopaFilmes.Domain.Core.Filmes.Services;
using Bigai.CopaFilmes.Domain.Shared.Interfaces;
using Bigai.CopaFilmes.Domain.Shared.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bigai.CopaFilmes.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfiguration>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            services.AddScoped<IFilmeService, FilmeService>();

            return services;
        }
    }
}
