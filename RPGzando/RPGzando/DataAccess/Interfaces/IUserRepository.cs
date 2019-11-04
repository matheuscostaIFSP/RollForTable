using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RPGzando.Models;

namespace RPGzando.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> PickUpUserLogged(ClaimsPrincipal user);
        Task<IdentityResult> SaveUser(User user, string password);
        Task UpdateUser(User user);
        Task AttributeLevelAccess(User user, string levelAccess);
        Task EffectLogin(User user, bool remember);
        Task EffectLogOut();
        Task<User> PickUpUserEmail(string email);


    }
}
