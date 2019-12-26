using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Posts
    {
        public string P_id { get; set; }
        public string P_theme { get; set; }
        public DateTime P_time { get; set; }
        public string P_account { get; set; }
        public string P_nick { get; set; }
        public string P_text { get; set; }
        public int P_good { get; set; }
        public int P_view { get; set; }
        public string P_plate { get; set; }
        public int P_state { get; set; }
        public string P_platename { get; set; }
    }
}
