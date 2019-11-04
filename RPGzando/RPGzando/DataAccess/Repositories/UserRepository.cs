using RPGzando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RPGzando.DataAccess.Interfaces;

namespace RPGzando.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SignInManager<User> _managerLogin;
        private readonly UserManager<User> _managerUser;

        public UserRepository(Context context, SignInManager<User> managerLogin, UserManager<User> managerUser) : base(context)
        {
            _managerLogin = managerLogin;
            _managerUser = managerUser;
        }

        public async Task<User> PickUpUserLogged(ClaimsPrincipal user)
        {
            return await _managerUser.GetUserAsync(user);
        }

        public async Task<IdentityResult> SaveUser(User user, string password)
        {
            return await _managerUser.CreateAsync(user, password);
        }

        public async Task AttributeLevelAccess(User user, string levelAccess)
        {
            await _managerUser.AddToRoleAsync(user, levelAccess);
        }

        public async Task EffectLogin(User user, bool remember)
        {
            await _managerLogin.SignInAsync(user, remember);
        }

        public async Task EffectLogOut()
        {
            await _managerLogin.SignOutAsync();
        }

        public async Task<User> PickUpUserEmail(string email)
        {
            return await _managerUser.FindByEmailAsync(email);
        }

        public async Task UpdateUser(User user)
        {
            await _managerUser.UpdateAsync(user);
        }
    }
}
