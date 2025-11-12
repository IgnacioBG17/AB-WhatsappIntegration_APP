using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WhatsappIntegration.Api.Services.WhatsappCloud.SendMessage
{
    public class WhatsappCloudSendMessage : IWhatsappCloudSendMessage
    {
        public async Task<bool> Execute(object model)
        {
            var client = new HttpClient();
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            using (var content = new ByteArrayContent(byteData))
            {
                string endpoint = "https://graph.facebook.com";
                string phoneNumberId = "916358451551107";
                string accessToken = "EAAdGxZBvVHMoBP5twsk2lID4RDZAV9cXDTvvHjZC4JPdY0Cyi4yQbr2awoZAcRlQ6wqhRf0MAwH7ZBYZA5zUbmrDNiCwCEA9cXPu6DfcbdZCRZBafdVNZAtrWb5g9sMZAZCmkcQAgzZBzfiHEllic1sHpfpcqZBS11lCZAr8yZByojZCtEoG1R4jaiZC1GsJtRdmAV60zUbXcwYZBgoG6VotOn8Ah1uHdQ2tu1zS2A3TGtYBDvJnO4ql7H7QvYvzo2LN5zYunYCs0jGFoycutqHtPTWzk9TAnGhXdgpgEZ";
                string uri = $"{endpoint}/v22.0/{phoneNumberId}/messages";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
