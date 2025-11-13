using Microsoft.AspNetCore.Mvc;
using WhatsappIntegration.Application.Service;
using WhatsappIntegration.Domain.Models.WhatsappCloud;

namespace WhatsappIntegration.Api.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        private readonly IWhatsAppMessageHandler _handler;
        private readonly IConfiguration _config;

        public WhatsappController(IWhatsAppMessageHandler handler, IConfiguration config)
        {
            _handler = handler;
            _config = config;
        }

        [HttpGet]
        public IActionResult VerifyToken()
        {
            var expectedToken = _config["WhatsAppSettings:Token"];
            var token = Request.Query["hub.verify_token"].ToString();
            var challenge = Request.Query["hub.challenge"].ToString();

            if (!string.IsNullOrEmpty(challenge) && token == expectedToken)
                return Ok(challenge);

            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveMessage([FromBody] WhatsAppCloudModel body)
        {
            await _handler.HandleAsync(body);
            return Ok("EVENT_RECEIVED");
        }
    }
}
