using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.DataAccess.Repositories
{
    public class LevelAccessRepository : GenericRepository<LevelAccesses>, ILevelAccessRepository
    {
        private readonly RoleManager<LevelAccesses> _managerLevelAccesses;
        private readonly Context _context;
        public LevelAccessRepository(Context context, RoleManager<LevelAccesses> managerLevelAccesses) : base(context)
        {
            _context = context;
            _managerLevelAccesses = managerLevelAccesses;
        }

        public async Task<bool> LevelAccessExist(string levelAccess)
        {
            return await _managerLevelAccesses.RoleExistsAsync(levelAccess);
        }
    }
}
