using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.MultiTenancy.Payments.Dto;
using CerZen.MultiTenancy.Payments.Stripe.Dto;

namespace CerZen.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}