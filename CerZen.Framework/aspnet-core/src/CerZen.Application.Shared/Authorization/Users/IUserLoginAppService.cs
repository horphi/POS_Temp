using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CerZen.Authorization.Users.Dto;

namespace CerZen.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
