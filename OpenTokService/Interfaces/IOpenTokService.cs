
using OpenTokSDK;
using OpenTokService.Models;

namespace OpenTokService.Interfaces
{
    public interface IOpenTokService
    {
        SessionModel GetSessionInfo();
        OpenTok GetOpenTok();
        Session GetSession();
    }
}
