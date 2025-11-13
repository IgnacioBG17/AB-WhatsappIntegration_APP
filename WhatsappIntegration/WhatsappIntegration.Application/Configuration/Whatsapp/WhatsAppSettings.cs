namespace WhatsappIntegration.Application.Configuration.Whatsapp
{
    public class WhatsAppSettings
    {
        public string? Endpoint { get; set; } = "https://graph.facebook.com";
        public string? ApiVersion { get; set; } = "v22.0";
        public string? PhoneNumberId { get; set; }
        public string? Token { get; set; }
        public string? AccessToken { get; set; }
    }
}
