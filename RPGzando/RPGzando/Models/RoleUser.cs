using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class RoleUser
    {
        public int RoleUserId { get; set; }
        public string NameRole { get; set; }
        public string DescriptionRole { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int TableGameId { get; set; }
        public TableGame TableGame { get; set; }
    }
}
