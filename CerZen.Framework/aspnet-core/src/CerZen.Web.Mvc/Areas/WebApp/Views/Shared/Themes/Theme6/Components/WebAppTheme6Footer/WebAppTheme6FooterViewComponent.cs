using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Areas.WebApp.Models.Layout;
using CerZen.Web.Session;
using CerZen.Web.Views;

namespace CerZen.Web.Areas.WebApp.Views.Shared.Themes.Theme6.Components.WebAppTheme6Footer
{
    public class WebAppTheme6FooterViewComponent : CerZenViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public WebAppTheme6FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
