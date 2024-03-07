using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerZen.Authorization.Permissions.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Common.Modals
{
    public class PermissionTreeModalViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }
        public List<string> GrantedPermissionNames { get; set; }
    }
}
