using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Areas.WebApp.Models.Layout;
using CerZen.Web.Views;

namespace CerZen.Web.Areas.WebApp.Views.Shared.Components.
    WebAppQuickThemeSelect
{
    public class WebAppQuickThemeSelectViewComponent : CerZenViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, string iconClass = "flaticon-interface-7 fs-2")
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass,
                IconClass = iconClass
            }));
        }
    }
}
