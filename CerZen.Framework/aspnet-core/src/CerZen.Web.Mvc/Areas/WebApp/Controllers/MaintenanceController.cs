using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using CerZen.Authorization;
using CerZen.Caching;
using CerZen.Web.Areas.WebApp.Models.Maintenance;
using CerZen.Web.Controllers;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Maintenance)]
    public class MaintenanceController : CerZenControllerBase
    {
        private readonly ICachingAppService _cachingAppService;

        public MaintenanceController(ICachingAppService cachingAppService)
        {
            _cachingAppService = cachingAppService;
        }

        public ActionResult Index()
        {
            var model = new MaintenanceViewModel
            {
                Caches = _cachingAppService.GetAllCaches().Items,
                CanClearAllCaches = _cachingAppService.CanClearAllCaches()
            };

            return View(model);
        }
    }
}