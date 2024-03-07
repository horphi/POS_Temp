using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Controllers;

namespace CerZen.Web.Public.Controllers
{
    public class HomeController : CerZenControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}