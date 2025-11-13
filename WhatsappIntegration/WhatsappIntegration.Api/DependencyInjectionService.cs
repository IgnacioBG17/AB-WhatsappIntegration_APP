using Microsoft.OpenApi;

namespace WhatsappIntegration.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WhatsApp Integration API",
                    Version = "v1",
                    Description = "API para integración con WhatsApp (Meta Cloud API)"
                });
            });
            return services;
        }
    }
}
