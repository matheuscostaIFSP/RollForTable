using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;
using RPGzando.ViewModels;

namespace RPGzando.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.PickUpUserLogged(User));
        }

        public async Task<IActionResult> Register()
        {
            if (User.Identity.IsAuthenticated)
                await _userRepository.EffectLogOut();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = register.Name,
                    Name = register.Name,
                    LastName = register.LastName,
                    Nickname = register.Nickname,
                    DateRegister = register.DateRegister,
                    PresentialUser = register.PresentialUser,
                    Latitude = register.Latitude,
                    Longitude = register.Longitude,
                    Email = register.Email,
                    PasswordHash = register.Password

                };
                var result = await _userRepository.SaveUser(user, register.Password);

                if (result.Succeeded)
                {
                    var levelAccess = "Administrador";

                    await _userRepository.AttributeLevelAccess(user, levelAccess);

                    await _userRepository.EffectLogin(user, false);

                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    foreach (var erro in result.Errors)
                        ModelState.AddModelError("", erro.Description.ToString());
                }
            }
            return View(register);
        }

        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
                await _userRepository.EffectLogOut();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.PickUpUserEmail(login.Email);
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

                if (user != null)
                {
                    if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password) !=
                        PasswordVerificationResult.Failed)
                    {
                        await _userRepository.EffectLogin(user, false);

                        return RedirectToAction("Index", "Users");
                    }

                    ModelState.AddModelError("", "Invalid Email and/or Password");
                }
                ModelState.AddModelError("", "Invalid Email and/or Password");
            }

            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string userId)
        {
            var user = await _userRepository.PickUpById(userId);

            var updateViewModel = new UpdateViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Nickname = user.Nickname,
                UserName = user.Name,
                DateRegister = user.DateRegister,
                PresentialUser = user.PresentialUser,
                Email = user.Email
            };

            return View(updateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateViewModel updateViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.PickUpById(updateViewModel.Id);

                user.Name = updateViewModel.Name;
                user.LastName = updateViewModel.LastName;
                user.Nickname = updateViewModel.Nickname;
                user.UserName = updateViewModel.Name;
                user.DateRegister = updateViewModel.DateRegister;
                user.PresentialUser = updateViewModel.PresentialUser;
                user.Email = updateViewModel.Email;

                await _userRepository.UpdateUser(user);

                return RedirectToAction("Index", "Users");
            }

            return View(updateViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _userRepository.EffectLogOut();

            return RedirectToAction("Login", "Users");
        }

    }
}