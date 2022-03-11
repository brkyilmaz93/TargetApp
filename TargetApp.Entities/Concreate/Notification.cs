using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetApp.Entities.Abstract;

namespace TargetApp.Entities.Concreate
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string Header { get; set; }

        public int MyAppHealthId { get; set; }

        public virtual MyAppHealth MyAppHealth { get; set; }

    }
}
