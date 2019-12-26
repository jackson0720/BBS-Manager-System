using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class UsersController : Controller
    {

        public ActionResult GetUsers(string uid)
        {
            Model.Users users = new BLL.UsersBLL().GetUsers(uid);

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListUserByUid(string account)
        {
            Model.Users users = new BLL.UsersBLL().GetUserByUid(account);

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateStateByUid(int state,string uid)
        {
            string msg = "";
            int i = new BLL.UsersBLL().UpdateStateByUid(state, uid);
            if (i > 0)
            {
                msg = "修改成功！";
            }
            else
            {
                msg = "修改失败！";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListUsers()
        {
            List<Model.Users> user = new BLL.UsersBLL().ListUsers();

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCount()
        {
            int i = new BLL.UsersBLL().CountUser();

            return Json(i, JsonRequestBehavior.AllowGet);
        }
    }
}