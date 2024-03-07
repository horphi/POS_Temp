using System.Linq;
using System.Threading.Tasks;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;
using CerZen.Web.Areas.WebApp.Models.Layout;
using CerZen.Web.Views;

namespace CerZen.Web.Areas.WebApp.Views.Shared.Components.WebAppLanguageSwitch
{
    public class WebAppLanguageSwitchViewComponent : CerZenViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public WebAppLanguageSwitchViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            var model = new LanguageSwitchViewModel
            {
                Languages = _languageManager.GetActiveLanguages().ToList(),
                CurrentLanguage = _languageManager.CurrentLanguage,
                CssClass = cssClass
            };
            
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
