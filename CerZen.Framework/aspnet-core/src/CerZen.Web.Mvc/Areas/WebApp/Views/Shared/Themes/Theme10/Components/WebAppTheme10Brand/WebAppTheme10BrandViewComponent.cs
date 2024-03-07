using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Areas.WebApp.Models.Layout;
using CerZen.Web.Session;
using CerZen.Web.Views;

namespace CerZen.Web.Areas.WebApp.Views.Shared.Themes.Theme10.Components.WebAppTheme10Brand
{
    public class WebAppTheme10BrandViewComponent : CerZenViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public WebAppTheme10BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
