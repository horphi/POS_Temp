using Cz.AspNetJarvisCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using CerZen.Configuration;
using CerZen.EntityFrameworkCore;
using CerZen.Migrator.DependencyInjection;

namespace CerZen.Migrator
{
    [DependsOn(typeof(CerZenEntityFrameworkCoreModule))]
    public class CerZenMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CerZenMigratorModule(CerZenEntityFrameworkCoreModule cerZenEntityFrameworkCoreModule)
        {
            cerZenEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CerZenMigratorModule).GetAssembly().GetDirectoryPathOrNull(),
                addUserSecrets: true
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CerZenConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
