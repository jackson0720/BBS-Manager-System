using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class UserGroupController : Controller
    {

        public ActionResult GetUserGroupByUid(string uid)
        {
            Model.UserGroup userGroup = new BLL.UserGroupBLL().GetUserGroupByUid(uid);

            return Json(userGroup, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateStateByUcode(int state,string ucode)
        {
            int i = new BLL.UserGroupBLL().UpdateStateByUcode(state,ucode);
            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListUtype()
        {
            List<Model.UserGroup> userGroups = new BLL.UserGroupBLL().ListUserGroup();

            return Json(userGroups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCount()
        {
            int count = new BLL.UserGroupBLL().Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
    }
}