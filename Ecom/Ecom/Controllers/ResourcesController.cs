using Ecom.DAL;
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
            try
            {
                string userType = string.Empty;

                using(DbEntities db = new DbEntities())
                {
                    if(ViewData["userType"] != null)
                    {
                        //userType = db.users.FirstOrDefault(x => x.userId == userId).userType;
                        ViewData["userType"] = userType;
                    }
                    var storeDetails = db.Stores.ToList();
                    return View(storeDetails);
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
        [HttpPost]
        public ActionResult Stores(int id)
        {
            return View();
        }
    }
}