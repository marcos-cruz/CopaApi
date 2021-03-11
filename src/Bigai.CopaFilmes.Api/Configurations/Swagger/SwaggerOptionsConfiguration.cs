using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace Bigai.CopaFilmes.Api.Configurations.Swagger
{
    public class SwaggerOptionsConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        #region Private Variables

        private readonly IApiVersionDescriptionProvider _provider;

        #endregion

        #region Constructor

        public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        #endregion

        #region Public Methods

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                options.IncludeXmlComments(xmlDocPath);
                options.SwaggerDoc(description.GroupName, GetOpenApiInfo(description));
            }
        }

        #endregion

        #region Private Methods

        private OpenApiInfo GetOpenApiInfo(ApiVersionDescription description)
        {
            OpenApiInfo apiInfo = new OpenApiInfo()
            {
                Title = "Copa Filmes API",
                Description = "Microservice do Campeonato de Filmes",
                Version = description.GroupName,
                Contact = new OpenApiContact()
                {
                    Name = "Marcos Cruz",
                    Email = "marcoscruz@terra.com.br"
                },
            };

            if (description.IsDeprecated)
            {
                apiInfo.Description += " Esta versão está obsoleta.";
            }

            return apiInfo;
        }

        #endregion
    }
}
