using Abp.Modules;
using Abp.Reflection.Extensions;

namespace CerZen
{
    public class CerZenCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenCoreSharedModule).GetAssembly());
        }
    }
}