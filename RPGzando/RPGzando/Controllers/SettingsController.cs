using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISettingRepository _settingRepository;

        public SettingsController(ISettingRepository settingRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _settingRepository = settingRepository;
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userRepository.PickUpUserLogged(User);
            var settingUser = new Setting { UserId = user.Id };
            return View(settingUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettingId,ReceiveEmail,ReceiveTelegram,Warning,Reminder,UserId")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                await _settingRepository.Insert(setting);
                return RedirectToAction("Index", "Users");
            }
            return View(setting);
        }

        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var setting = await _settingRepository.PickUpById(id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,ReceiveEmail,ReceiveTelegram,Warning,Reminder,UserId")] Setting setting)
        {
            if (id != setting.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _settingRepository.Update(setting);

                return RedirectToAction("Index", "Users");
            }
            return View(setting);
        }

        // POST: Settings/Delete/5
        [HttpPost]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            {
                await _settingRepository.Delete(id);
                return Json("Excluded Time");
            }
        }

    }
}
