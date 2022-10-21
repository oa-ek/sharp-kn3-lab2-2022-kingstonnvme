using Microsoft.AspNetCore.Mvc;
using Rozklad.Repos;
using Rozklad.UI.Models;
using System.Diagnostics;
using Rozklad.Repos.Dto;

namespace Rozklad.UI.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly BusSheduleRepository busRepository;

        public HomeController(BusSheduleRepository busRepository)
        {
            this.busRepository = busRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await busRepository.GetBusSheduleAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}