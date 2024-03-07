using System.Threading.Tasks;
using Abp.Dependency;

namespace CerZen.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}