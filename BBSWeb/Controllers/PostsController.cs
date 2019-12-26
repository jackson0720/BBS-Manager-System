using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class PostsController : Controller
    {

        public ActionResult ListPostsByPid(string pid)
        {
            Model.Posts posts = new BLL.PostsBLL().GetPostsByPid(pid);

            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeOpera(int state, string pid)
        {
            int i = new BLL.PostsBLL().DelPostsByPid(state,pid);
            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPostsTextByPid(string pid)
        {
            Model.Posts posts = new BLL.PostsBLL().GetPostsTextByPid(pid);

            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListPosts()
        {
            List<Model.Posts> posts = new BLL.PostsBLL().GetPosts();

            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCount()
        {
            int count = new BLL.PostsBLL().CountPosts();
            return Json(count,JsonRequestBehavior.AllowGet);
        }
    }
}