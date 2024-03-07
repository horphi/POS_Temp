using System.Collections.Generic;
using CerZen.Caching.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
        
        public bool CanClearAllCaches { get; set; }
    }
}