using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CerZen.Authorization.Permissions.Dto;

namespace CerZen.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
