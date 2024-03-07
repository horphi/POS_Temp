using System.Collections.Generic;
using Abp.Application.Services.Dto;
using CerZen.Authorization.Permissions.Dto;
using CerZen.Web.Areas.WebApp.Models.Common;

namespace CerZen.Web.Areas.WebApp.Models.Users
{
    public class UsersViewModel : IPermissionsEditViewModel
    {
        public string FilterText { get; set; }

        public List<ComboboxItemDto> Roles { get; set; }

        public bool OnlyLockedUsers { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
