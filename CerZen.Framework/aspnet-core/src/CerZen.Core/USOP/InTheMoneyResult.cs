using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerZen.USOP
{
    public class EventsPointTier
    {
        public string EventCode { get; set; }
        public string EventName { get; set; }
        public decimal PrizePool { get; set; }
        public int Entries { get; set; }
        public decimal BuyInAmount { get; set; }
        public string PointsTier { get; set; }
        public int Rank { get; set; }
        public int PotsPoint { get; set; }

    }

    public class InTheMoneyResult : Entity<Guid>
    {
        public string EventCode { get; set; }

        public string EventName { get; set; }

        public int Rank { get; set; }

        public string PlayerName { get; set; }

        public decimal PrizePool { get; set; }

        public int Entries { get; set; }

        public decimal BuyInAmount { get; set; }

        public int PotsPoint { get; set; }

    }

    public class PlayerPotsPoint
    {
        public PlayerPotsPoint()
        {
            WonEvents = new List<EventsPointTier>();
        }
        public string PlayerName { get; set; }
        public int FinalPosition { get; set; }
        public int TotalPotsPoints { get; set; }
        public List<EventsPointTier> WonEvents { get; set; }
    }
    
  
}
