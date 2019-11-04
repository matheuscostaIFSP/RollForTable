using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime? DateRegister { get; set; }
        public bool PresentialUser { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<Card> Cards { get; set; }
        public ICollection<HoraryUser> HoraryUsers { get; set; }
        public ICollection<TablePlayer> TablePlayers { get; set; }
        public ICollection<RegisteredPlayer> RegisteredPlayers { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
        public Setting Setting { get; set; }

    }
}
