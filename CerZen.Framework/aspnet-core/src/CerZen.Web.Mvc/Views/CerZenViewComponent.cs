using Abp.AspNetCore.Mvc.ViewComponents;

namespace CerZen.Web.Views
{
    public abstract class CerZenViewComponent : AbpViewComponent
    {
        protected CerZenViewComponent()
        {
            LocalizationSourceName = CerZenConsts.LocalizationSourceName;
        }
    }
}