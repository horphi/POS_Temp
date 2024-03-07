using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.Install.Dto;

namespace CerZen.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}