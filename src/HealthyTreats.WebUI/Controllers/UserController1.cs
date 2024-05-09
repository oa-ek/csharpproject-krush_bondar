using HealthyTreats.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTreats.WebUI.Controllers
{
    public class UserController1 : Controller
    {
        private readonly IUsersRepository usersRepository;
        public UserController1(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await usersRepository.GetAllWithRolesAsync());
        }
    }
}
