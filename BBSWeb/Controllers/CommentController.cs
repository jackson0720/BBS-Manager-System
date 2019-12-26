using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class CommentController : Controller
    {

        public ActionResult ListCommentsByCid(string cid)
        {
            List<Model.Comment> comments = new BLL.CommentBLL().ListCommentsByCid(cid);

            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeOpera(int state,int cno)
        {
            int i = new BLL.CommentBLL().DelCommentByCno(state, cno);

            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListComment()
        {
            List<Model.Comment> cmt = new BLL.CommentBLL().ListComment();

            return Json(cmt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCount()
        {
            int count = new BLL.CommentBLL().CountComment();
            return Json(count, JsonRequestBehavior.AllowGet);
        }

    }
}