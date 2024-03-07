using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace CerZen.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
