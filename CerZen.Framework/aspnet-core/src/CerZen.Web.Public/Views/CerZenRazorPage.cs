using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace CerZen.Web.Public.Views
{
    public abstract class CerZenRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected CerZenRazorPage()
        {
            LocalizationSourceName = CerZenConsts.LocalizationSourceName;
        }
    }
}
