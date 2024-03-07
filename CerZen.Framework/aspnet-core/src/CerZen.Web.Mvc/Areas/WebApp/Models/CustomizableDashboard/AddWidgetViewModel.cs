using System.Collections.Generic;
using CerZen.DashboardCustomization.Dto;

namespace CerZen.Web.Areas.WebApp.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
