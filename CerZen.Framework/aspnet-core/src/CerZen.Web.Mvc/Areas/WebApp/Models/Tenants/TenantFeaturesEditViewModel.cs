using Abp.AutoMapper;
using CerZen.MultiTenancy;
using CerZen.MultiTenancy.Dto;
using CerZen.Web.Areas.WebApp.Models.Common;

namespace CerZen.Web.Areas.WebApp.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}