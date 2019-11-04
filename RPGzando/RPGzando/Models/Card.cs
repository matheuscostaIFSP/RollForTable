using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string NameCharacter { get; set; }
        public string PdfLink { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<TableSystemCard> TableSystemCards { get; set; }
    }
}
