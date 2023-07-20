using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom.Controllers
{
    public class ResourcesController : Controller
    {
        [HttpGet]
        public ActionResult Services()
        {
            if(Session["user"]!=null)
            {
                return View();
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
        }
        [HttpPost]
        public ActionResult Services(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Stores()
        {
            return View();
        }
    }
}