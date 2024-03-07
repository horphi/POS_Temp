using Cz.AspNetJarvisCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using CerZen.Configuration;
using CerZen.EntityFrameworkCore;

namespace CerZen.Web.Public.Startup
{
    [DependsOn(
        typeof(CerZenWebCoreModule)
    )]
    public class CerZenWebFrontEndModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CerZenWebFrontEndModule(IWebHostEnvironment env, CerZenEntityFrameworkCoreModule cerZenEntityFrameworkCoreModule)
        {
            _appConfiguration = env.GetAppConfiguration();
            cerZenEntityFrameworkCoreModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:WebSiteRootAddress"] ?? "https://localhost:44303/";

            //Changed AntiForgery token/cookie names to not conflict to the main application while redirections.
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenCookieName = "Public-XSRF-TOKEN";
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenHeaderName = "Public-X-XSRF-TOKEN";

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenWebFrontEndModule).GetAssembly());
        }
    }
}
