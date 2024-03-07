using Abp.AspNetCore.Mvc.Views;

namespace CerZen.Web.Views
{
    public abstract class CerZenRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected CerZenRazorPage()
        {
            LocalizationSourceName = CerZenConsts.LocalizationSourceName;
        }
    }
}
