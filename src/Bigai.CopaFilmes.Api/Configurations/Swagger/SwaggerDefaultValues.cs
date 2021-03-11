using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Bigai.CopaFilmes.Api.Configurations.Swagger
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters != null)
            {
                foreach (OpenApiParameter parameter in operation.Parameters.OfType<OpenApiParameter>())
                {
                    ApiParameterDescription description = context.ApiDescription
                        .ParameterDescriptions
                        .First(p => p.Name == parameter.Name);

                    ApiParameterRouteInfo routeInfo = description.RouteInfo;

                    operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                    if (parameter.Description == null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }

                    if (routeInfo != null)
                    {
                        if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                        {
                            parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
                        }

                        parameter.Required |= description.IsRequired;
                    }
                }
            }
        }
    }
}
