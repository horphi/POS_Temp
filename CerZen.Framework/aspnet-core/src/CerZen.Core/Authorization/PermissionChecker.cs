using Abp.Authorization;
using CerZen.Authorization.Roles;
using CerZen.Authorization.Users;

namespace CerZen.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
