using System.Collections.Generic;
using Cz.AspNetJarvisCore;
using Cz.AspNetJarvisCore.Web.Authentication.External;
using Cz.AspNetJarvisCore.Web.Authentication.External.Facebook;
using Cz.AspNetJarvisCore.Web.Authentication.External.Google;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Abp.Timing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using CerZen.Auditing;
using CerZen.Authorization.Users.Password;
using CerZen.Configuration;
using CerZen.EntityFrameworkCore;
using CerZen.MultiTenancy;
using CerZen.Web.Startup.ExternalLoginInfoProviders;

namespace CerZen.Web.Startup
{
    [DependsOn(
        typeof(CerZenWebCoreModule)
    )]
    public class CerZenWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CerZenWebHostModule(
            IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat =
                _appConfiguration["App:ServerRootAddress"] ?? "https://localhost:44301/";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenWebHostModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            using (var scope = IocManager.CreateScope())
            {
                if (!scope.Resolve<DatabaseCheckHelper>().Exist(_appConfiguration["ConnectionStrings:Default"]))
                {
                    return;
                }
            }

            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            if (IocManager.Resolve<IMultiTenancyConfig>().IsEnabled)
            {
                workManager.Add(IocManager.Resolve<SubscriptionExpirationCheckWorker>());
                workManager.Add(IocManager.Resolve<SubscriptionExpireEmailNotifierWorker>());
                workManager.Add(IocManager.Resolve<SubscriptionPaymentNotCompletedEmailNotifierWorker>());
            }

            var expiredAuditLogDeleterWorker = IocManager.Resolve<ExpiredAuditLogDeleterWorker>();
            if (Configuration.Auditing.IsEnabled && expiredAuditLogDeleterWorker.IsEnabled)
            {
                workManager.Add(expiredAuditLogDeleterWorker);
            }

            workManager.Add(IocManager.Resolve<PasswordExpirationBackgroundWorker>());
            
            ConfigureExternalAuthProviders();
        }

        private void ConfigureExternalAuthProviders()
        {
            var externalAuthConfiguration = IocManager.Resolve<ExternalAuthConfiguration>();


            if (bool.Parse(_appConfiguration["Authentication:Facebook:IsEnabled"]))
            {
                if (bool.Parse(_appConfiguration["Authentication:AllowSocialLoginSettingsPerTenant"]))
                {
                    externalAuthConfiguration.ExternalLoginInfoProviders.Add(
                        IocManager.Resolve<TenantBasedFacebookExternalLoginInfoProvider>());
                }
                else
                {
                    externalAuthConfiguration.ExternalLoginInfoProviders.Add(new FacebookExternalLoginInfoProvider(
                        _appConfiguration["Authentication:Facebook:AppId"],
                        _appConfiguration["Authentication:Facebook:AppSecret"]
                    ));
                }
            }

            if (bool.Parse(_appConfiguration["Authentication:Google:IsEnabled"]))
            {
                if (bool.Parse(_appConfiguration["Authentication:AllowSocialLoginSettingsPerTenant"]))
                {
                    externalAuthConfiguration.ExternalLoginInfoProviders.Add(
                        IocManager.Resolve<TenantBasedGoogleExternalLoginInfoProvider>());
                }
                else
                {
                    externalAuthConfiguration.ExternalLoginInfoProviders.Add(
                        new GoogleExternalLoginInfoProvider(
                            _appConfiguration["Authentication:Google:ClientId"],
                            _appConfiguration["Authentication:Google:ClientSecret"],
                            _appConfiguration["Authentication:Google:UserInfoEndpoint"]
                        )
                    );
                }
            }


        }
    }
}
