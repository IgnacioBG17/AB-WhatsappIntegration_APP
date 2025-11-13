namespace WhatsappIntegration.Application.Contracts.External
{
    public interface IMessageBuilder
    {
        object BuildText(string body, string to);
        object BuildImage(string url, string to, string? caption = null);
        object BuildDocument(string url, string to, string? caption = null, string? fileName = null);
        object BuildVideo(string url, string to, string? caption = null);
        object BuildAudio(string url, string to);
        object BuildLocation(string to);
        object BuildMainMenuList(string to);
    }
}
