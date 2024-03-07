using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using CerZen.Configuration.Tenants.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
        
        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}
