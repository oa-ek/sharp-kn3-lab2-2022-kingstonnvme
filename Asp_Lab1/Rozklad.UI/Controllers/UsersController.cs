using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repos;

namespace Rozklad.UI.Controllers
{
    [Authorize(Roles="Admin")]
    public class UsersController : Controller
    {
        private readonly UsersRepository usersRepository;

        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }


        public async Task<IActionResult> Index()
        {
            return View(await  usersRepository.GetUsersAsync());
        }
    }
}
