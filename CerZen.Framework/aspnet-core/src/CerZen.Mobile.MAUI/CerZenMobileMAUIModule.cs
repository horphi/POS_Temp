using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CerZen.ApiClient;
using CerZen.Mobile.MAUI.Core.ApiClient;

namespace CerZen
{
    [DependsOn(typeof(CerZenClientModule), typeof(AbpAutoMapperModule))]

    public class CerZenMobileMAUIModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.ReplaceService<IApplicationContext, MAUIApplicationContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenMobileMAUIModule).GetAssembly());
        }
    }
}