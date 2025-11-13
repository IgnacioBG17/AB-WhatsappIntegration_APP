using WhatsappIntegration.Application.Contracts.External;

namespace WhatsappIntegration.External.Helpers
{
    internal class MessageBuilder : IMessageBuilder
    {
        public object BuildText(string body, string to) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "text",
            text = new { body }
        };

        public object BuildImage(string url, string to, string? caption = null) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "image",
            image = new { link = url, caption }
        };

        public object BuildDocument(string url, string to, string? caption = null, string? fileName = null) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "document",
            document = new { link = url, caption, filename = fileName }
        };

        public object BuildVideo(string url, string to, string? caption = null) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "video",
            video = new { link = url, caption }
        };

        public object BuildAudio(string url, string to) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "audio",
            audio = new { link = url }
        };

        public object BuildLocation(string to) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "location",
            location = new
            {
                latitude = "12.136389",
                longitude = "-86.252006",
                name = "Sucursal Metrocentro Managua",
                address = "Rotonda Rubén Darío, Managua, Nicaragua"
            }
        };

        public object BuildMainMenuList(string to) => new
        {
            messaging_product = "whatsapp",
            to,
            type = "interactive",
            interactive = new
            {
                type = "list",
                header = new { type = "text", text = "Servicios disponibles" },
                body = new { text = "Selecciona una categoría 👇" },
                footer = new { text = "Banco ProFin · Atención 24/7" },
                action = new
                {
                    button = "Ver opciones",
                    sections = new[]
                    {
                    new {
                        title = "Consultas",
                        rows = new[]
                        {
                            new { id = "SALDO",     title = "Consultar saldo 💰" },
                            new { id = "ESTADOCTA", title = "Estado de cuenta 📄" },
                            new { id = "PROMO",     title = "Promociones 🎥" },
                            new { id = "SUCURSAL",  title = "Sucursal 🏦" }
                        }
                }
            }
                }
            }
        };

    }
}
