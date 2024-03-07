using Abp.AspNetCore.Mvc.Authorization;
using CerZen.USOP;
using CerZen.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Linq;
using System.Threading.Tasks;
using CerZen.Web.Areas.WebApp.Models.UsopPots;
using Humanizer;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    [AbpMvcAuthorize]
    public class UsopPotsController : CerZenControllerBase
    {
        private readonly IUsopPotsAppService _usopPotsAppService;

        public UsopPotsController(IUsopPotsAppService usopPotsAppService)
        {
            _usopPotsAppService = usopPotsAppService;
        }   

        public async Task< IActionResult> Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Danang()
        {
            var events = await  _usopPotsAppService.GetEventPointTier(TournamentNameConst.Danang);
            var playerPots = await _usopPotsAppService.GetPlayerPotsPoint(TournamentNameConst.Danang);
            var topTenPlayers= playerPots.Take(10).ToList();
            
            var model = new IndexViewModel();
            model.Events = events;
            model.PlayerPotsPoints = playerPots;
            model.TopTenPlayers = topTenPlayers;
            return View(model);
        }
        
        public async Task<IActionResult> Taipei()
        {
            var events = await  _usopPotsAppService.GetEventPointTier(TournamentNameConst.Taipei);
            var playerPots = await _usopPotsAppService.GetPlayerPotsPoint(TournamentNameConst.Taipei);
            var topTenPlayers= playerPots.Take(10).ToList();
            
            var model = new IndexViewModel();
            model.Events = events;
            model.PlayerPotsPoints = playerPots;
            model.TopTenPlayers = topTenPlayers;
            return View(model);
        }
    }
}