using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetApp.Entities.General
{
    public class Messages<T> where T: class, new () 
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int RecordId { get; set; }
        public T Record { get; set; }
        public List<T> List { get; set; }

    }
}
