using System.Threading.Tasks;
using CerZen.Sessions.Dto;

namespace CerZen.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
