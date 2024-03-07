using System.Threading.Tasks;
using Abp.Application.Services;
using CerZen.Sessions.Dto;

namespace CerZen.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
