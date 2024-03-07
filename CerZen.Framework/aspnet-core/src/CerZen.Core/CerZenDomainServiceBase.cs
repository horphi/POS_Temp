using Abp.Domain.Services;

namespace CerZen
{
    public abstract class CerZenDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected CerZenDomainServiceBase()
        {
            LocalizationSourceName = CerZenConsts.LocalizationSourceName;
        }
    }
}
