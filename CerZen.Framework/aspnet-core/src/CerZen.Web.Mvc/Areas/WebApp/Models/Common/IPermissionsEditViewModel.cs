using System.Collections.Generic;
using CerZen.Authorization.Permissions.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}