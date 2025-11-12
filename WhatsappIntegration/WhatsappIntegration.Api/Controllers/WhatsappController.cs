using Microsoft.AspNetCore.Mvc;
using WhatsappIntegration.Api.Models.WhatsappCloud;
using WhatsappIntegration.Api.Services.WhatsappCloud.SendMessage;
using WhatsappIntegration.Api.Util;

namespace WhatsappIntegration.Api.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;
        private readonly IUtil _util;

        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage, IUtil util)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
            _util = util;
        }

        [HttpGet("sample")]
        public async Task<IActionResult> Sample()
        {
            var data = new
            {
                messaging_product = "whatsapp",
                to = "",
                type = "text",
                text = new
                {
                    body = "hola desde app .NET"
                }
            };
            var result = await _whatsappCloudSendMessage.Execute(data);
            return Ok("Ok sample");
        }

        [HttpGet]
        public IActionResult VerifyToken()
        {
            string accessToken = "SHAFJHI#@HFJHKJHIUWTYISGDFLKJHAKJDSHF";
            var token = Request.Query["hub.verify_token"].ToString();
            var challenge = Request.Query["hub.challenge"].ToString();

            if (challenge != null && token != null && token == accessToken)
            {
                return Ok(challenge);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReceivedMessage([FromBody] WhatsAppCloudModel body)
        {
            try
            {
                var message = body.Entry[0]?.Changes[0]?.Value?.Messages[0];
                if (message != null)
                {
                    var userNumber = message.From;
                    var userText = GetUserText(message);

                    object objectMessage;
                    switch (userText.ToUpper())
                    {
                        case "COMPRAR":
                            objectMessage = _util.TextMessage("Has seleccionado comprar, excelete desicion !", userNumber);
                            break;
                        case "TEXT":
                            objectMessage = _util.TextMessage("Este es un ejemplo de texto", userNumber);
                            break;
                        case "IMAGE":
                            objectMessage = _util.ImageMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/image_whatsapp.png", userNumber);
                            break;
                        case "AUDIO":
                            objectMessage = _util.AudioMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/audio_whatsapp.mp3", userNumber);
                            break;
                        case "VIDEO":
                            objectMessage = _util.VideoMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/video_whatsapp.mp4", userNumber);
                            break;
                        case "DOCUMENT":
                            objectMessage = _util.DocumentMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/document_whatsapp.pdf", userNumber);
                            break;
                        case "LOCATION":
                            objectMessage = _util.LocationMessage(userNumber);
                            break;
                        case "BUTTON":
                            objectMessage = _util.ButtonsMessage(userNumber);
                            break;
                        default:
                            objectMessage = _util.TextMessage("Lo siento, no puedo entenderte", userNumber);
                            break;
                    }

                    await _whatsappCloudSendMessage.Execute(objectMessage);
                }
                return Ok("EVENT_RECEIVED");
            }
            catch (Exception ex)
            {
                return Ok("EVENT_RECEIVED");
            }
        }

        private string GetUserText(Message message)
        {
            string TypeMessage = message.Type;

            if (TypeMessage.ToUpper() == "TEXT")
            {
                return message.Text.Body;
            }
            else if (TypeMessage.ToUpper() == "INTERACTIVE")
            {
                string interactiveType = message.Interactive.Type;

                if (interactiveType.ToUpper() == "LIST_REPLY")
                {
                    return message.Interactive.List_Reply.Title;
                }
                else if (interactiveType.ToUpper() == "BUTTON_REPLY")
                {
                    return message.Interactive.Button_Reply.Title;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
