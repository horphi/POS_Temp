using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.MultiTenancy.Payments.PayPal.Dto;

namespace CerZen.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
