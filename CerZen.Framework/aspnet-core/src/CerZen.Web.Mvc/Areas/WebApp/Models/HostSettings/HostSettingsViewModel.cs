using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using CerZen.Configuration.Host.Dto;
using CerZen.Editions.Dto;

namespace CerZen.Web.Areas.WebApp.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();


    }
}
