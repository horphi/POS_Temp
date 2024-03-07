using System.Collections.Generic;
using CerZen.Authorization.Delegation;
using CerZen.Authorization.Users.Delegation.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
