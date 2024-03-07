using Abp.Modules;
using Abp.Reflection.Extensions;

namespace CerZen
{
    public class CerZenClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenClientModule).GetAssembly());
        }
    }
}
