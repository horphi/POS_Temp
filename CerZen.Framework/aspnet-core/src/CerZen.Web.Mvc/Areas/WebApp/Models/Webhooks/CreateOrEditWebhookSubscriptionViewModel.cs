using Abp.Application.Services.Dto;
using Abp.Webhooks;
using CerZen.WebHooks.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
