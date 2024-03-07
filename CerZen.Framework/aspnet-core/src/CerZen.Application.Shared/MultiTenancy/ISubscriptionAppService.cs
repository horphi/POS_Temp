using System.Threading.Tasks;
using Abp.Application.Services;

namespace CerZen.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
