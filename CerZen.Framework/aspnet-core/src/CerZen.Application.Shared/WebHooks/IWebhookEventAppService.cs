using System.Threading.Tasks;
using Abp.Webhooks;

namespace CerZen.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
