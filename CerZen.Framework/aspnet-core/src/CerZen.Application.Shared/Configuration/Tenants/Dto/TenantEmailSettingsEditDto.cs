using Abp.Auditing;
using CerZen.Configuration.Dto;

namespace CerZen.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}