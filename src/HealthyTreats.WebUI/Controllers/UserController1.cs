using HealthyTreats.Repositories.Models;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserCreateModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usersRepository.CreateWithPasswordAsync(model);

                if (user != null)
                {
                    return RedirectToAction(nameof(Edit), new { id = user.Id });
                }

               
            }

            return View(new UserCreateModel());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Roles = await usersRepository.GetRolesAsync();
            return View(await usersRepository.GetOneWithRolesAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserListItemModel model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await usersRepository.UpdateUserAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await usersRepository.GetRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<int> CheckDelete(Guid id)
        {
            var check = await usersRepository.CheckUser(id);
            return check ? 1 : 0;
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await usersRepository.DeleteUser(id);
        }
    }
}