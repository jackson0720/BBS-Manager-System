using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OperationlogDAL
    {

        public int Insertoperationlog(Model.Operationlog operationlog)
        {
            string sql = "insert into operationlog values('"+operationlog.Log_id+"','"+operationlog.Log_admin+"','"+operationlog.Log_date+"','"+operationlog.Log_text+"','"+operationlog.Log_state+"')";
            return SQLHelp.ExecQuery(sql);
        }

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select Count(*) from operationlog");
        }

        public List<Model.Operationlog> Listoperationlogs()
        {
            List<Model.Operationlog> opl = new List<Model.Operationlog>();

            if (SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from operationlog order by log_date desc");

                if (dr != null)
                {
                    while (dr.Read())
                         opl.Add(new Model.Operationlog() { Log_id = dr["log_id"] as string,Log_admin = dr["log_admin"] as string,Log_date = (DateTime)dr["log_date"],Log_text=dr["log_text"] as string,Log_state = (int)dr["log_state"]});

                    dr.Close();
                    SQLHelp.CloseConnection();
                }
            }
            return opl;
        }
    }
}
