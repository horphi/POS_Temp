using System.Collections.Generic;
using CerZen.Editions;
using CerZen.Editions.Dto;
using CerZen.MultiTenancy.Payments;
using CerZen.MultiTenancy.Payments.Dto;

namespace CerZen.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
