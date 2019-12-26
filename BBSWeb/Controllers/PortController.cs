using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class PortController : Controller
    {
        public ActionResult UpdateStateAndSuccessByPid(int state,int success,string pid)
        {
            int i = new BLL.PortBLL().UpdateStateAndSuccessByPid(state, success, pid);

            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPortByPid(string pid)
        {
            Model.Port port = new BLL.PortBLL().GetPortByPid(pid);

            return Json(port, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListPort()
        {
            List<Model.Port> ports = new BLL.PortBLL().ListPort();

            return Json(ports, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Count()
        {
            int i = new BLL.PortBLL().Count();
            return Json(i, JsonRequestBehavior.AllowGet);
        }

    }
}