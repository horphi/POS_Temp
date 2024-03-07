using System.Threading.Tasks;
using CerZen.Authorization.Users;

namespace CerZen.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
