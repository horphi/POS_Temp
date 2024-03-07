using Abp.Dependency;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.Extensions.Options;
using CerZen.Configuration;

namespace CerZen.Web.Startup.AuthConfigurers
{
    public class ExternalLoginOptionsCacheManager : IExternalLoginOptionsCacheManager, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IOptionsMonitorCache<FacebookOptions> _facebookOptionsCache;
        private readonly IOptionsMonitorCache<GoogleOptions> _googleOptionsCache;
        private readonly IOptionsMonitorCache<MicrosoftAccountOptions> _microsoftOptionsCache;

        public ExternalLoginOptionsCacheManager(
            IOptionsMonitorCache<FacebookOptions> facebookOptionsCache,
            IOptionsMonitorCache<GoogleOptions> googleOptionsCache,
            IOptionsMonitorCache<MicrosoftAccountOptions> microsoftOptionsCache
            )
        {
            AbpSession = NullAbpSession.Instance;

            _facebookOptionsCache = facebookOptionsCache;
            _googleOptionsCache = googleOptionsCache;
            _microsoftOptionsCache = microsoftOptionsCache;

        }

        public void ClearCache()
        {
            ClearFacebookCache();
            ClearGoogleCache();
            ClearMicrosoftAccountOptionsCache();
            //add your other caches here
        }


        private void ClearMicrosoftAccountOptionsCache()
        {
            _microsoftOptionsCache.TryRemove(GetCacheKey("Microsoft"));
        }

        private void ClearGoogleCache()
        {
            _googleOptionsCache.TryRemove(GetCacheKey("Google"));
        }

        private void ClearFacebookCache()
        {
            _facebookOptionsCache.TryRemove(GetCacheKey("Facebook"));
        }

        private string GetCacheKey(string name)
        {
            if (AbpSession.TenantId.HasValue)
            {
                return $"{name}-{AbpSession.TenantId.Value}";
            }

            return name;
        }
    }
}
