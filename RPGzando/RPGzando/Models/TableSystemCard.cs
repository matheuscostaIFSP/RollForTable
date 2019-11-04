using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class TableSystemCard
    {
        public int TableSystemCardId { get; set; }
        public string SystemCard { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int TableGameId { get; set; }
        public TableGame TableGame { get; set; }

    }
}
