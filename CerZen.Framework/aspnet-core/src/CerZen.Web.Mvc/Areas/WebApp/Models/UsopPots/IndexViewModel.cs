using CerZen.USOP;
using System.Collections.Generic;

namespace CerZen.Web.Areas.WebApp.Models.UsopPots
{
    public class IndexViewModel
    {
        public List<EventsPointTier> Events {get;set; }
        public List<PlayerPotsPoint> PlayerPotsPoints { get; set; }
        public List<PlayerPotsPoint> TopTenPlayers { get; set; }
        
        public IndexViewModel()
        {
            Events = new List<EventsPointTier>();
            PlayerPotsPoints = new List<PlayerPotsPoint>();
            TopTenPlayers = new List<PlayerPotsPoint>();
        }
    }
}
