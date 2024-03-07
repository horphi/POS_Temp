using System.Collections.Generic;
using CerZen.Editions.Dto;
using CerZen.MultiTenancy.Payments;

namespace CerZen.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}