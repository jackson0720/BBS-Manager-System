using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace MISbbs.Controllers
{

    public class LoginController : Controller
    {
        public static string name = null;

        public ActionResult Login(string name, string password)
        {
            //从表单集合中读取数据
            Model.Admin admin = new Model.Admin
            {
                A_account = name,
                A_pwd = password
            };
            Model.Admin amin = new BLL.AdminBLL().Login(admin);
            Session["user"] = amin.A_name;
            Session["account"] = amin.A_account;
            Session["state"] = amin.A_state;

            return Json(amin.A_pwd,JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult Index()
        {
            return Json(Session["user"],JsonRequestBehavior.AllowGet);
        }

        public JsonResult Account()
        {
            return Json(Session["account"], JsonRequestBehavior.AllowGet);
        }

        public JsonResult State()
        {
            return Json(Session["state"], JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClearSession()
        {
            Session.Clear();
            Session.Abandon();
            this.Response.Cookies.Add(new HttpCookie("account", string.Empty) { HttpOnly = true });
            this.Response.Cookies.Add(new HttpCookie("user", string.Empty) { HttpOnly = true });
            return Json("安全退出成功！即将跳转到登录界面！", JsonRequestBehavior.AllowGet);
        }
    }

}