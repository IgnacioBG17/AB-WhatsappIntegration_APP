using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WhatsappIntegration.Application.Configuration.Whatsapp;
using WhatsappIntegration.Application.Contracts.WhatsappCloud.SendMessage;

namespace WhatsappIntegration.External.WhatsappCloud.SendMessage
{
    public class WhatsappCloudSendMessage : IWhatsappCloudSendMessage
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppSettings _whatsAppSettings;

        public WhatsappCloudSendMessage(
            HttpClient httpClient,
            IOptions<WhatsAppSettings> whatsAppSettings)
        {
            _httpClient = httpClient;
            _whatsAppSettings = whatsAppSettings.Value;

            // Se configura una sola vez (no se repite por petición)
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _whatsAppSettings.AccessToken);
        }

        public async Task<bool> Execute(object model)
        {
            var uri = $"{_whatsAppSettings.Endpoint}/{_whatsAppSettings.ApiVersion}/{_whatsAppSettings.PhoneNumberId}/messages";

            var content = new StringContent(
                JsonConvert.SerializeObject(model),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ Error WhatsApp API: {response.StatusCode} - {errorDetails}");
                return false;
            }

            return true;
        }
    }
}
