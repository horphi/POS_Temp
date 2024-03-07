using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Areas.WebApp.Models.Layout;
using CerZen.Web.Views;

namespace CerZen.Web.Areas.WebApp.Views.Shared.Components.WebAppToggleDarkMode
{
    public class WebAppToggleDarkModeViewComponent : CerZenViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, bool isDarkModeActive)
        {
            return Task.FromResult<IViewComponentResult>(View(new ToggleDarkModeViewModel(cssClass, isDarkModeActive)));
        }
    }
}