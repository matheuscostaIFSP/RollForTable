using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class Setting
    {
        public int SettingId { get; set; }
        public bool ReceiveEmail { get; set; }
        public bool ReceiveTelegram { get; set; }
        public bool Warning { get; set; }
        public bool Reminder { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
