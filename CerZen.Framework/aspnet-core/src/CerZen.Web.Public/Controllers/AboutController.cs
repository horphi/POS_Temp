using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Controllers;

namespace CerZen.Web.Public.Controllers
{
    public class AboutController : CerZenControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}