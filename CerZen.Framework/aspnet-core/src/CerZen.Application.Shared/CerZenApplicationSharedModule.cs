using Abp.Modules;
using Abp.Reflection.Extensions;

namespace CerZen
{
    [DependsOn(typeof(CerZenCoreSharedModule))]
    public class CerZenApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenApplicationSharedModule).GetAssembly());
        }
    }
}