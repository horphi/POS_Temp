using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.Editions.Dto;
using CerZen.MultiTenancy.Dto;

namespace CerZen.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}