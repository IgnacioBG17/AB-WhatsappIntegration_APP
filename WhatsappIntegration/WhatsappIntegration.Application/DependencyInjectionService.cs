using Microsoft.Extensions.DependencyInjection;
using WhatsappIntegration.Application.Service;

namespace WhatsappIntegration.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IWhatsAppMessageHandler, WhatsAppMessageHandler>();
            return services;
        }
    }
}
