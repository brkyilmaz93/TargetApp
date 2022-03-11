using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetApp.Entities.Abstract;
using TargetApp.Entities.Concreate;

namespace TargetApp.Entities.Concreate
{
    public class MyAppInfo :BaseEntity
    {
        public string Url { get; set; }
        public string TargetName { get; set; }
        public int PeriodicallyTimeForCheck { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
       
    }
}
