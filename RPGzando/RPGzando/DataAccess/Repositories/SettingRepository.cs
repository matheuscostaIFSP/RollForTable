using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.DataAccess.Repositories
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(Context context) : base(context)
        {

        }
    }
}
