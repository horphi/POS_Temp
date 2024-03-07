using System.Collections.Generic;
using CerZen.Authorization.Permissions.Dto;

namespace CerZen.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}