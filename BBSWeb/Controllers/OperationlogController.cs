using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class OperationlogController : Controller
    {

        public JsonResult Count()
        {
            int i = new BLL.OperationlogBLL().Count();
            return Json(i, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListOperationlog()
        {
            List<Model.Operationlog> operationlogs = new BLL.OperationlogBLL().Listoperationlogs();

            return Json(operationlogs, JsonRequestBehavior.AllowGet);
        }


        public JsonResult InsertOperalog(string log_admin,string log_text)
        {
            string date = DateTime.Now.ToString();
            string date1 = DateTime.Now.ToShortDateString();
            Random rdm = new Random();
            Model.Operationlog operationlog = new Model.Operationlog
            {
                Log_id = date1.Replace("/", "") + rdm.Next(1, 9) + rdm.Next(1, 9) + rdm.Next(1, 9) + rdm.Next(1, 9),
                Log_admin = log_admin,
                Log_date = Convert.ToDateTime(date),
                Log_text = log_text,
                Log_state = 0
            };
            string msg = new BLL.OperationlogBLL().Insertoperationlog(operationlog);

            return Json(msg, JsonRequestBehavior.AllowGet);

        }
    }
}