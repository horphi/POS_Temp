using System.Collections.Generic;
using CerZen.Editions.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}