using CerZen.Editions;
using CerZen.Editions.Dto;
using CerZen.MultiTenancy.Payments;
using CerZen.Security;
using CerZen.MultiTenancy.Payments.Dto;

namespace CerZen.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
