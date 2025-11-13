using WhatsappIntegration.Domain.Models.WhatsappCloud;

namespace WhatsappIntegration.Application.Service
{
    public interface IWhatsAppMessageHandler
    {
        Task HandleAsync(WhatsAppCloudModel body);
    }
}
