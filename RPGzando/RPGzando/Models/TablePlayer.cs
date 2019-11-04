using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class TablePlayer
    {
        public int TablePlayerId { get; set; }
        public string UserId { get; set; }       
        public User User { get; set; }
        public int TableGameId { get; set; }
        public TableGame TableGame { get; set; }
        public DateTime? DateIngress { get; set; }
    }
}
