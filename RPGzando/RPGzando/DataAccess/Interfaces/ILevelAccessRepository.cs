using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGzando.Models;

namespace RPGzando.DataAccess.Interfaces
{
    public interface ILevelAccessRepository : IGenericRepository<LevelAccesses>
    {
        Task<bool> LevelAccessExist(string levelAccess);
    }
}
