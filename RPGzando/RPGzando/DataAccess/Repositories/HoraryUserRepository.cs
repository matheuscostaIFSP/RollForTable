using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.DataAccess.Repositories
{
    public class HoraryUserRepository : GenericRepository<HoraryUser>, IHoraryUserRepository
    {
        public HoraryUserRepository(Context context) : base(context)
        {
        }
    }
}
