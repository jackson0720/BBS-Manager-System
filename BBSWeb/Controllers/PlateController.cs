using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Controllers
{
    public class PlateController : Controller
    {
        public JsonResult ListPlate()
        {
            List<Model.Plate> plate = new BLL.PlateBLL().GetPlate();

            return Json(plate, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CountPlate()
        {
            int count = new BLL.PlateBLL().CountPlate();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
    }
}