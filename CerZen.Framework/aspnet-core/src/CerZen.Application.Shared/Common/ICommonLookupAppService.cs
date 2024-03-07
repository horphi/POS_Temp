using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CerZen.Common.Dto;
using CerZen.Editions.Dto;

namespace CerZen.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}