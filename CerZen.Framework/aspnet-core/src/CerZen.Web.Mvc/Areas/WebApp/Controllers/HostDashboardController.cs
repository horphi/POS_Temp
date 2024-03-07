using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using CerZen.Authorization;
using CerZen.DashboardCustomization;
using System.Threading.Tasks;
using CerZen.Web.Areas.WebApp.Startup;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : CustomizableDashboardControllerBase
    {
        public HostDashboardController(
            DashboardViewConfiguration dashboardViewConfiguration,
            IDashboardCustomizationAppService dashboardCustomizationAppService)
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(CerZenDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard);
        }
    }
}