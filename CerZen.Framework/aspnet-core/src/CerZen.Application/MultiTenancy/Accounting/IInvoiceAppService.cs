using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using CerZen.MultiTenancy.Accounting.Dto;

namespace CerZen.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
