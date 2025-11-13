using WhatsappIntegration.Application.Contracts.External;
using WhatsappIntegration.Application.Contracts.WhatsappCloud.SendMessage;
using WhatsappIntegration.Domain.Models.WhatsappCloud;

namespace WhatsappIntegration.Application.Service
{
    public class WhatsAppMessageHandler : IWhatsAppMessageHandler
    {
        private readonly IWhatsappCloudSendMessage _sender;
        private readonly IMessageBuilder _builder;

        public WhatsAppMessageHandler(IWhatsappCloudSendMessage sender, IMessageBuilder builder)
        {
            _sender = sender;
            _builder = builder;
        }
        public async Task HandleAsync(WhatsAppCloudModel body)
        {
            var message = body.Entry[0].Changes[0].Value.Messages[0];
            var userNumber = message.From;
            var userText = GetUserText(message).ToUpperInvariant();

            object reply = userText switch
            {
                "CONSULTAR SALDO 💰" => _builder.BuildText("Tu saldo actual es C$ 15,430.00", userNumber),
                "ESTADO DE CUENTA 📄" => _builder.BuildDocument(
                                    "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
                                    userNumber,
                                    "Aquí está tu estado de cuenta 📄",
                                    "EstadoCuenta.pdf"),
                "SUCURSAL 🏦" => _builder.BuildLocation(userNumber),
                "PROMOCIONES 🎥" => _builder.BuildVideo(
                                    "https://download.samplelib.com/mp4/sample-5s.mp4",
                                    userNumber,
                                    "Mira nuestras nuevas promociones 🎥"),
                string t when   t.Contains("MENU") || t.Contains("MENÚ") ||
                                t.Contains("HOLA") || t.Contains("AYUDA")
                 => _builder.BuildMainMenuList(userNumber),
          
                string t when t.Contains("GRACIAS")
                    => _builder.BuildText(
                        "Gracias a ti por confiar en nosotros. Si necesitas algo más, solo escribe *MENÚ* y con gusto te ayudo de nuevo.",
                        userNumber),

                string t when t.Contains("ADIOS") || t.Contains("ADIÓS") ||
                             t.Contains("HASTA LUEGO") || t.Contains("BYE") ||
                             t.Contains("CHAO") || t.Contains("CIAO")
                    => _builder.BuildText(
                        "👋 Ha sido un gusto ayudarte. Que tengas un excelente día. Recuerda que estoy disponible 24/7 si me necesitas.",
                        userNumber),
                _ => _builder.BuildText("No te entendí. Escribe *MENU* para ver opciones.", userNumber)
            };

            await _sender.Execute(reply);
        }

        private string GetUserText(Message message)
        {
            var type = message.Type?.ToUpperInvariant();

            return type switch
            {
                "TEXT" => message.Text?.Body ?? string.Empty,
                "INTERACTIVE" => message.Interactive?.Type?.ToUpperInvariant() switch
                {
                    "LIST_REPLY" => message.Interactive.List_Reply?.Title ?? string.Empty,
                    "BUTTON_REPLY" => message.Interactive.Button_Reply?.Id
                                        ?? string.Empty,
                    _ => string.Empty
                },
                _ => string.Empty
            };
        }
    }
}
