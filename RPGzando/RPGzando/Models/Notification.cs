using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string TitleNotification { get; set; }
        public string Message { get; set; }
        public ICollection<TablePlayerNotification> TablePlayerNotifications { get; set; }
    }
}
