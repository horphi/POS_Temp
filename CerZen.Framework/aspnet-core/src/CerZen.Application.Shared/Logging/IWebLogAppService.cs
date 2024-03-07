using Abp.Application.Services;
using CerZen.Dto;
using CerZen.Logging.Dto;

namespace CerZen.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
