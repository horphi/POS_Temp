using System.Collections.Generic;
using Abp.Localization;
using CerZen.Install.Dto;

namespace CerZen.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
