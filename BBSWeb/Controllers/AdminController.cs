using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult AddAdmin(string account,string password,string name) 
        {
            Model.Admin admin = new Model.Admin
            {
                A_account = account,
                A_pwd = password,
                A_name = name
            };
            int i = new BLL.AdminBLL().AddAdmin(admin);
            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeOpera(int state, string cno)
        {
            int i = new BLL.AdminBLL().ChangeAdminStateByAid(state, cno);

            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAdmin()
        {
            List<Model.Admin> admins = new BLL.AdminBLL().ListAdmins();

            return Json(admins, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Count()
        {
            int i = new BLL.AdminBLL().Count();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
    }
}