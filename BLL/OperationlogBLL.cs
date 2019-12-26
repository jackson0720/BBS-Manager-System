using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OperationlogBLL
    {

        public int Count()
        {
            return (int)SQLHelp.ExecScalar("select Count(*) from operationlog");
        }

        public string Insertoperationlog(Model.Operationlog operationlog)
        {
            string sql = "insert into operationlog values('" + operationlog.Log_id + "','" + operationlog.Log_admin + "','" + operationlog.Log_date + "','" + operationlog.Log_text + "','" + operationlog.Log_state + "')";
            int i =  SQLHelp.ExecQuery(sql);
            if (i > 0)
            {
                return "已记录！";
            }
            else
            {
                return "服务器繁忙！";
            }
            
        }


        public List<Model.Operationlog> Listoperationlogs()
        {
            return new DAL.OperationlogDAL().Listoperationlogs();
        }
    }
}
