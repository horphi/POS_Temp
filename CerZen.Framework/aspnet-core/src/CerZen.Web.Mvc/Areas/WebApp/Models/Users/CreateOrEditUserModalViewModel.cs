﻿using System.Linq;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using CerZen.Authorization.Users.Dto;
using CerZen.Security;
using CerZen.Web.Areas.WebApp.Models.Common;

namespace CerZen.Web.Areas.WebApp.Models.Users
{
    [AutoMapFrom(typeof(GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput, IOrganizationUnitsEditViewModel
    {
        public bool CanChangeUserName => User.UserName != AbpUserBase.AdminUserName;

        public int AssignedRoleCount
        {
            get { return Roles.Count(r => r.IsAssigned); }
        }

        public bool IsEditMode => User.Id.HasValue;

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }
    }
}