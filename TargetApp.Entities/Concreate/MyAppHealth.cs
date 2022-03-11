using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetApp.Entities.Abstract;

namespace TargetApp.Entities.Concreate
{
    public class MyAppHealth : BaseEntity
    {
        public int MyAppInfoId { get; set; }
        public string StatusCode{ get; set; }
        public virtual MyAppInfo MyAppInfo { get; set; }
        public virtual Notification Notification { get; set; }




    }
}
