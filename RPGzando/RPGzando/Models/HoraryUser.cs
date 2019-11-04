using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGzando.Models
{
    public class HoraryUser
    {
        public int HoraryUserId { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string DateAvailable { get; set; }

        [Required(ErrorMessage = "Required field")]
        public TimeSpan HoraryUserInitial { get; set; }

        [Required(ErrorMessage = "Required field")]
        public TimeSpan HoraryUserFinal { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
