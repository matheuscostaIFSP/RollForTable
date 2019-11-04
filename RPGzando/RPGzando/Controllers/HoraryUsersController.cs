using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.Controllers
{
    public class HoraryUsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IHoraryUserRepository _horaryUserRepository;

        public HoraryUsersController(IUserRepository userRepository, IHoraryUserRepository horaryUserRepository)
        {
            _userRepository = userRepository;
            _horaryUserRepository = horaryUserRepository;
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userRepository.PickUpUserLogged(User);
            var horaryUser = new HoraryUser {UserId = user.Id};
            return View(horaryUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoraryUserId,DateAvailable,HoraryUserInitial,HoraryUserFinal,UserId")] HoraryUser horaryUser)
        {
            if (ModelState.IsValid)
            {
                await _horaryUserRepository.Insert(horaryUser);
                return RedirectToAction("Index", "Users");
            }
            return View(horaryUser);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var horaryUser = await _horaryUserRepository.PickUpById(id);
            if (horaryUser == null)
            {
                return NotFound();
            }

            return View(horaryUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoraryUserId,DateAvailable,HoraryUserInitial,HoraryUserFinal,UserId")] HoraryUser horaryUser)
        {
            if (id != horaryUser.HoraryUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _horaryUserRepository.Update(horaryUser);
                
                return RedirectToAction("Index", "Users");
            }
            return View(horaryUser);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _horaryUserRepository.Delete(id);
            return Json("Excluded Time");
        }
    }
}
