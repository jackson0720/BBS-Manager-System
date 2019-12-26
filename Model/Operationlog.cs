using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Operationlog
    {
        public string Log_id { get; set; }
        public string Log_admin { get; set; }
        public DateTime Log_date { get; set; }
        public string Log_text { get; set; }
        public int Log_state { get; set; }


    }
}
