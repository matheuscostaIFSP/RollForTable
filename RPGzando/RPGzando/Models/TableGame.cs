using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class TableGame
    {
        public int TableGameId { get; set; }
        public string Title { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateInitial { get; set; }
        public int TableDuration { get; set; }
        public string System { get; set; }
        public string DescriptionGame { get; set; }
        public string Theme { get; set; }
        public string QuantityPeople { get; set; }
        public string LinkDiscord { get; set; }
        public string Photo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool Presential { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<TablePlayer> TablePlayers { get; set; }
        public ICollection<HoraryTable> HoraryTables { get; set; }
        public ICollection<RegisteredPlayer> RegisteredPlayer { get; set; }
        public ICollection<TablePlayerNotification> TablePlayerNotifications { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
        public ICollection<TableSystemCard> TableSystemCards { get; set; }
    }
}
