using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PortDAL
    {

        public int UpdateStateAndSuccessByPid(int state,int success,string pid)
        {
            return SQLHelp.ExecQuery("update port set p_success = '" + success + "',p_state = '" + state + "' where p_no = '" + pid + "'");
        }

        public Model.Port GetPortByPid(string pid)
        {
            Model.Port port = new Model.Port();
            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from port where p_no = '" + pid + "'");

                if (dr != null)
                {
                    if (dr.Read())
                    port.P_no = dr["p_no"] as string;
                    port.P_account = dr["p_account"] as string;
                    port.P_type = dr["p_type"] as string;
                    port.P_title = dr["p_title"] as string;
                    port.P_text = dr["p_text"] as string;
                    port.P_time = (DateTime)dr["p_time"];
                    port.P_success = (int)dr["p_success"];
                    port.P_state = (int)dr["p_state"];
                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return port;
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select Count(*) from Port");
        }

        public List<Model.Port> ListPort()
        {
            List<Model.Port> ports = new List<Model.Port>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from port order by p_time desc");

                if (dr != null)
                {
                    while (dr.Read())
                        ports.Add(new Model.Port() { P_no = dr["p_no"] as string,P_account = dr["p_account"] as string,P_type = dr["p_type"] as string,P_title = dr["p_title"] as string,P_text = dr["p_text"] as string,P_time = (DateTime)dr["p_time"],P_success = (int)dr["p_success"],P_state = (int)dr["p_state"]});

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return ports;

        }
    }
}
