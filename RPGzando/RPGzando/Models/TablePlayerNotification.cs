using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class TablePlayerNotification
    {
        public int TpNotificationId { get; set; }
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public int TableGameId { get; set; }
        public TableGame TableGame { get; set; }
    }
}
