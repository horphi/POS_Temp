using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using CerZen.Authorization;
using CerZen.DashboardCustomization;
using System.Threading.Tasks;
using CerZen.Web.Areas.WebApp.Startup;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(CerZenDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}