using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatsappIntegration.Application.Configuration.Whatsapp;
using WhatsappIntegration.Application.Contracts.External;
using WhatsappIntegration.Application.Contracts.WhatsappCloud.SendMessage;
using WhatsappIntegration.External.Helpers;
using WhatsappIntegration.External.WhatsappCloud.SendMessage;

namespace WhatsappIntegration.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
                                                     IConfiguration configuration)
        {
            services.Configure<WhatsAppSettings>(configuration.GetSection("WhatsAppSettings"));
            services.AddSingleton<IMessageBuilder, MessageBuilder>();
            services.AddSingleton<IWhatsappCloudSendMessage, WhatsappCloudSendMessage>();
            return services;
        }
    }
}
