using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class HoraryTable
    {
        public int HoraryTableId { get; set; }
        public string DateAvailableTable { get; set; }
        public TimeSpan HoraryTableInitial { get; set; }
        public TimeSpan HoraryTableFinal { get; set; }

        public int TableGameId { get; set; }
        public TableGame TableGame { get; set; }
    }
}
