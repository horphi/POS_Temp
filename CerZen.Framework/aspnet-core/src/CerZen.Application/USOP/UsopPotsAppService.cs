using Abp.Application.Services;
using Microsoft.AspNetCore.Hosting;
using NUglify.JavaScript.Syntax;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CerZen.Localization.Dto;

namespace CerZen.USOP
{
    public interface IUsopPotsAppService : IApplicationService
    {
        Task<List<EventsPointTier>> GetEventPointTier(string tournament);
        Task<List<PlayerPotsPoint>> GetPlayerPotsPoint(string tournament);
    }

    public class UsopPotsAppService : CerZenAppServiceBase, IUsopPotsAppService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UsopPotsAppService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<List<InTheMoneyResult>> GetJsonResults(string tournament)
        {
            var wwwRootPath = _hostingEnvironment.WebRootPath;
            string resultJsonFile = System.IO.Path.Combine(wwwRootPath, "data", tournament, "results.json");
            string resultJson = System.IO.File.ReadAllText(resultJsonFile);
            var results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InTheMoneyResult>>(resultJson);
            return results;
        }


        public async Task<List<EventsPointTier>> GetEventPointTier(string tournament)
        {
            var results = await GetJsonResults(tournament);
            //distinct by event name
            var events = results.Select(r => r.EventCode).Distinct().ToList();
            var eventPointTierList = new List<EventsPointTier>();
            foreach (var eventCode in events)
            {
                var eventPointTier = new EventsPointTier();
                var result = results.FirstOrDefault(r => r.EventCode == eventCode);


                eventPointTier.EventName = result.EventName;
                eventPointTier.EventCode = result.EventCode;
                eventPointTier.Entries = result.Entries;
                eventPointTier.BuyInAmount = result.BuyInAmount;
                eventPointTier.PrizePool = result.PrizePool;
                eventPointTier.PointsTier = GetPointTier(result.BuyInAmount, result.PrizePool);
                eventPointTierList.Add(eventPointTier);
            }

            return eventPointTierList;
        }

        // public async Task<List<PlayerPotsPoint>> GetTopTenPlayers(string tournament)
        // {
        //     var topTenResults = (await GetPlayerPotsPoint(tournament)).Take(10);
        //     var results = await GetJsonResults(tournament);
        //     foreach (var result in topTenResults)
        //     {
        //         var eventWons = results.Where(r => r.PlayerName == result.PlayerName).ToList();
        //         foreach (var eventWon in eventWons)
        //         {
        //             var eventPointTier = new EventsPointTier();
        //             eventPointTier.EventName = eventWon.EventName;
        //             eventPointTier.EventCode = eventWon.EventCode;
        //             eventPointTier.Entries = eventWon.Entries;
        //             eventPointTier.BuyInAmount = eventWon.BuyInAmount;
        //             eventPointTier.PrizePool = eventWon.PrizePool;
        //             eventPointTier.Rank = eventWon.Rank;
        //             eventPointTier.PotsPoint = GetPotsPoint(eventWon.PrizePool, eventWon.BuyInAmount, eventWon.Rank);
        //             eventPointTier.PointsTier = GetPointTier(eventWon.BuyInAmount, eventWon.PrizePool);
        //             result.WonEvents.Add(eventPointTier);
        //         }
        //     }
        //
        //     return topTenResults.ToList();
        // }

        public async Task<List<PlayerPotsPoint>> GetPlayerPotsPoint(string tournament)
        {
            var results = await GetJsonResults(tournament);

            foreach (var result in results)
            {
                result.PotsPoint = GetPotsPoint(result.PrizePool, result.BuyInAmount, result.Rank);
            }

            var playerPotsPoint = new List<PlayerPotsPoint>();
            foreach (var result in results)
            {
                var player = playerPotsPoint.FirstOrDefault(p => p.PlayerName == result.PlayerName);
                if (player == null)
                {
                    playerPotsPoint.Add(new PlayerPotsPoint
                        { PlayerName = result.PlayerName, TotalPotsPoints = result.PotsPoint });
                }
                else
                {
                    player.TotalPotsPoints += result.PotsPoint;
                }
            }

            playerPotsPoint = playerPotsPoint.OrderByDescending(r => r.TotalPotsPoints).ToList();

            //include event won
            foreach (var result in playerPotsPoint)
            {
                var eventWons = results.Where(r => r.PlayerName == result.PlayerName).ToList();
                foreach (var eventWon in eventWons)
                {
                    var eventPointTier = new EventsPointTier();
                    eventPointTier.EventName = eventWon.EventName;
                    eventPointTier.EventCode = eventWon.EventCode;
                    eventPointTier.Entries = eventWon.Entries;
                    eventPointTier.BuyInAmount = eventWon.BuyInAmount;
                    eventPointTier.PrizePool = eventWon.PrizePool;
                    eventPointTier.Rank = eventWon.Rank;
                    eventPointTier.PotsPoint = GetPotsPoint(eventWon.PrizePool, eventWon.BuyInAmount, eventWon.Rank);
                    eventPointTier.PointsTier = GetPointTier(eventWon.BuyInAmount, eventWon.PrizePool);
                    result.WonEvents.Add(eventPointTier);
                }
            }

            return playerPotsPoint;
        }


        private int GetPotsPoint(decimal prizePool, decimal buyInAmount, int rank)
        {
            var pointTier = GetPointTier(buyInAmount, prizePool);
            var posPoint = GetRankPoint(rank, pointTier);
            return posPoint;
        }

        #region Formula

        private string GetPointTier(decimal buyInAmount, decimal prizePool)
        {
            if (buyInAmount < 249)
            {
                return GetTier(prizePool, 25000, 50000, 75000, 100000, 150000, 250000, 350000);
            }
            else if (buyInAmount >= 250 && buyInAmount <= 499)
            {
                return GetTier(prizePool, 50000, 75000, 100000, 150000, 250000, 350000, 500000);
            }
            else if (buyInAmount >= 500 && buyInAmount <= 999)
            {
                return GetTier(prizePool, 75000, 125000, 180000, 250000, 350000, 500000, 750000);
            }
            else if (buyInAmount >= 1000 && buyInAmount <= 2999)
            {
                return GetTier(prizePool, 100000, 150000, 250000, 350000, 500000, 750000, 1000000);
            }
            else if (buyInAmount >= 3000 && buyInAmount <= 9999)
            {
                return GetTier(prizePool, 150000, 250000, 350000, 500000, 750000, 1000000, 1500000);
            }
            else if (buyInAmount >= 10000)
            {
                return GetTier(prizePool, 250000, 350000, 500000, 750000, 1000000, 1500000, 2000000);
            }

            return "";
        }

        private string GetTier(decimal prizePool, params decimal[] thresholds)
        {
            char tier = 'A';
            for (int i = 0; i < thresholds.Length; i++)
            {
                if (prizePool < thresholds[i])
                {
                    return tier.ToString();
                }

                tier++;
            }

            return tier.ToString();
        }

        private int GetRankPoint(int rank, string col)
        {
            Dictionary<int, Dictionary<string, int>> pointsTable = new Dictionary<int, Dictionary<string, int>>
            {
                {
                    1,
                    new Dictionary<string, int>
                    {
                        { "A", 500 }, { "B", 550 }, { "C", 600 }, { "D", 650 }, { "E", 700 }, { "F", 750 },
                        { "G", 800 }, { "H", 900 }
                    }
                },
                {
                    2,
                    new Dictionary<string, int>
                    {
                        { "A", 375 }, { "B", 425 }, { "C", 450 }, { "D", 500 }, { "E", 525 }, { "F", 550 },
                        { "G", 600 }, { "H", 700 }
                    }
                },
                {
                    3,
                    new Dictionary<string, int>
                    {
                        { "A", 300 }, { "B", 350 }, { "C", 375 }, { "D", 400 }, { "E", 425 }, { "F", 450 },
                        { "G", 500 }, { "H", 600 }
                    }
                },
                {
                    4,
                    new Dictionary<string, int>
                    {
                        { "A", 250 }, { "B", 275 }, { "C", 300 }, { "D", 325 }, { "E", 350 }, { "F", 375 },
                        { "G", 400 }, { "H", 500 }
                    }
                },
                {
                    5,
                    new Dictionary<string, int>
                    {
                        { "A", 200 }, { "B", 225 }, { "C", 250 }, { "D", 250 }, { "E", 275 }, { "F", 300 },
                        { "G", 300 }, { "H", 400 }
                    }
                },
                {
                    6,
                    new Dictionary<string, int>
                    {
                        { "A", 150 }, { "B", 175 }, { "C", 200 }, { "D", 200 }, { "E", 225 }, { "F", 250 },
                        { "G", 250 }, { "H", 300 }
                    }
                },
                {
                    7,
                    new Dictionary<string, int>
                    {
                        { "A", 125 }, { "B", 125 }, { "C", 150 }, { "D", 150 }, { "E", 175 }, { "F", 200 },
                        { "G", 200 }, { "H", 250 }
                    }
                },
                {
                    8,
                    new Dictionary<string, int>
                    {
                        { "A", 100 }, { "B", 100 }, { "C", 125 }, { "D", 125 }, { "E", 125 }, { "F", 150 },
                        { "G", 150 }, { "H", 200 }
                    }
                },
                {
                    9,
                    new Dictionary<string, int>
                    {
                        { "A", 85 }, { "B", 90 }, { "C", 100 }, { "D", 100 }, { "E", 100 }, { "F", 125 }, { "G", 125 },
                        { "H", 150 }
                    }
                },
                {
                    10,
                    new Dictionary<string, int>
                    {
                        { "A", 55 }, { "B", 60 }, { "C", 75 }, { "D", 75 }, { "E", 75 }, { "F", 100 }, { "G", 100 },
                        { "H", 125 }
                    }
                },
                {
                    11,
                    new Dictionary<string, int>
                    {
                        { "A", 35 }, { "B", 45 }, { "C", 50 }, { "D", 50 }, { "E", 50 }, { "F", 75 }, { "G", 75 },
                        { "H", 100 }
                    }
                },
                {
                    12,
                    new Dictionary<string, int>
                    {
                        { "A", 35 }, { "B", 45 }, { "C", 50 }, { "D", 50 }, { "E", 50 }, { "F", 75 }, { "G", 75 },
                        { "H", 100 }
                    }
                },
                {
                    13,
                    new Dictionary<string, int>
                    {
                        { "A", 35 }, { "B", 45 }, { "C", 50 }, { "D", 50 }, { "E", 50 }, { "F", 75 }, { "G", 75 },
                        { "H", 100 }
                    }
                },
                {
                    14,
                    new Dictionary<string, int>
                    {
                        { "A", 35 }, { "B", 45 }, { "C", 50 }, { "D", 50 }, { "E", 50 }, { "F", 75 }, { "G", 75 },
                        { "H", 100 }
                    }
                },
                {
                    15,
                    new Dictionary<string, int>
                    {
                        { "A", 35 }, { "B", 45 }, { "C", 50 }, { "D", 50 }, { "E", 50 }, { "F", 75 }, { "G", 75 },
                        { "H", 100 }
                    }
                },
                {
                    16,
                    new Dictionary<string, int>
                    {
                        { "A", 15 }, { "B", 20 }, { "C", 25 }, { "D", 25 }, { "E", 25 }, { "F", 50 }, { "G", 50 },
                        { "H", 75 }
                    }
                }
            };

            if (pointsTable.TryGetValue(rank, out var rankPoint) && rankPoint.TryGetValue(col, out var points))
            {
                return points;
            }

            return -1;
        }

        #endregion


        //public string GetPointTier(decimal buyInAmount, decimal prizePool)
        //{
        //    if (buyInAmount < 249)
        //    {
        //        if (prizePool < 25000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 25000 && prizePool < 50000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 50000 && prizePool < 75000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 75000 && prizePool < 100000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 100000 && prizePool < 150000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 150000 && prizePool < 250000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 350000)
        //        {
        //            return "H";
        //        }

        //    }
        //    else if (buyInAmount >= 250 && buyInAmount <= 499)
        //    {
        //        if (prizePool < 50000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 50000 && prizePool < 75000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 75000 && prizePool < 100000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 100000 && prizePool < 150000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 150000 && prizePool < 250000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 350000 && prizePool < 500000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 500000)
        //        {
        //            return "H";
        //        }
        //    }
        //    else if (buyInAmount >= 500 && buyInAmount <= 999)
        //    {
        //        if (prizePool < 75000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 75000 && prizePool < 125000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 125000 && prizePool < 180000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 180000 && prizePool < 250000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 350000 && prizePool < 500000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 500000 && prizePool < 750000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 750000)
        //        {
        //            return "H";
        //        }
        //    }
        //    else if (buyInAmount >= 1000 && buyInAmount <= 2999)
        //    {
        //        if (prizePool < 100000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 100000 && prizePool < 150000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 150000 && prizePool < 250000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 350000 && prizePool < 500000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 500000 && prizePool < 750000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 750000 && prizePool < 1000000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 1000000)
        //        {
        //            return "H";
        //        }
        //    }
        //    else if (buyInAmount >= 3000 && buyInAmount <= 9999)
        //    {
        //        if (prizePool < 150000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 150000 && prizePool < 250000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 350000 && prizePool < 500000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 500000 && prizePool < 750000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 750000 && prizePool < 1000000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 1000000 && prizePool < 1500000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 1500000)
        //        {
        //            return "H";
        //        }
        //    }
        //    else if (buyInAmount >= 10000)
        //    {
        //        if (prizePool < 250000)
        //        {
        //            return "A";
        //        }
        //        else if (prizePool >= 250000 && prizePool < 350000)
        //        {
        //            return "B";
        //        }
        //        else if (prizePool >= 350000 && prizePool < 500000)
        //        {
        //            return "C";
        //        }
        //        else if (prizePool >= 500000 && prizePool < 750000)
        //        {
        //            return "D";
        //        }
        //        else if (prizePool >= 750000 && prizePool < 1000000)
        //        {
        //            return "E";
        //        }
        //        else if (prizePool >= 1000000 && prizePool < 1500000)
        //        {
        //            return "F";
        //        }
        //        else if (prizePool >= 1500000 && prizePool < 2000000)
        //        {
        //            return "G";
        //        }
        //        else if (prizePool >= 2000000)
        //        {
        //            return "H";
        //        }
        //    }

        //    return "";

        //}
    }
}