using System.Collections.Generic;
using Abp.Application.Services.Dto;
using CerZen.Authorization.Permissions.Dto;
using CerZen.Web.Areas.WebApp.Models.Common;

namespace CerZen.Web.Areas.WebApp.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}