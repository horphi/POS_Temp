using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace CerZen.Startup
{
    [DependsOn(typeof(CerZenCoreModule))]
    public class CerZenGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}