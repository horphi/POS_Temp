using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using CerZen.Authorization.Users;
using CerZen.MultiTenancy;

namespace CerZen.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}