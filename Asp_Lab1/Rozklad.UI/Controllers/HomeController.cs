using Microsoft.AspNetCore.Mvc;
using Rozklad.Repos;
using Rozklad.UI.Models;
using System.Diagnostics;
using Rozklad.Repos.Dto;
using Rozklad.Core;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(BusSheduleCreateDto model)
        {
           //if(ModelState.IsValid)
            //{
                BusShedule shedule = await busRepository.CreateBusSheduleAsync(model.DepartureTime, model.Busroute,model.mapsRoute, model.Seats, model.carrier, model.status, model.ArrivalTime, model.Cost);
                return RedirectToAction("Index", "Home", new { id = shedule.Id });
            //}

            //return View(model);

        }

      //  [HttpGet]

        /*public async Task<IActionResult> Delete(string id)
        {
            return View(await usersRepository.GetUsersAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await usersRepository.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
      }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}