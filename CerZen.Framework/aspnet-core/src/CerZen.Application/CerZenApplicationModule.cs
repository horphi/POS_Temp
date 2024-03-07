using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CerZen.Authorization;

namespace CerZen
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(CerZenApplicationSharedModule),
        typeof(CerZenCoreModule)
        )]
    public class CerZenApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenApplicationModule).GetAssembly());
        }
    }
}