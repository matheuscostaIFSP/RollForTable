using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.DataAccess.Repositories
{
    public class TableGameRepository : GenericRepository<TableGame>, ITableGameRepository
    {
        public TableGameRepository(Context context) : base(context)
        {
        }
    }
}
