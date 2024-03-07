using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.Configuration.Host.Dto;

namespace CerZen.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
