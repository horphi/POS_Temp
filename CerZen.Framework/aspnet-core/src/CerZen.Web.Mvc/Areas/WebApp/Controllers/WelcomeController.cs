using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Controllers;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    [AbpMvcAuthorize]
    public class WelcomeController : CerZenControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}