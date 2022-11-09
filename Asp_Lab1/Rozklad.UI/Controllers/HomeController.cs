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
        private readonly RozkladContext _ctx;
        private readonly BusSheduleRepository busRepository;

        public HomeController(BusSheduleRepository busRepository, RozkladContext ctx)
        {
            this.busRepository = busRepository;
            _ctx = ctx;
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

       [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
           
            if (id != 0)
            {
                return View(await busRepository.GetBusSheduleAsync(id));
            }
            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            
            if (id != 0)
            {
                await busRepository.DeleteBusSheduleAsync(id);
            return RedirectToAction("Index");
        }
    return NotFound();
    }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            
            return View(await busRepository.GetBusSheduleEditAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(BusSheduleReadDto model)
        {
           // if (ModelState.IsValid)
          //  {
                await busRepository.UpdateAsync(model);
                return RedirectToAction("Index");
          //  }
          //  return View(model);

        
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