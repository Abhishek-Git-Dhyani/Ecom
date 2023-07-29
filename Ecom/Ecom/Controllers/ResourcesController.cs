using Ecom.DAL;
using Ecom.Models;
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
                    ViewData["userType"] = GlobalFields.userType;
                    var storeDetails = db.Stores.ToList();
                    return View(storeDetails);
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
        [HttpGet]
        public ActionResult addStore()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addStore(Store store)
        {
            try
            {
                if(ModelState.IsValid == true)
                {
                    using (DbEntities db = new DbEntities())
                    {
                        db.Stores.Add(store);
                        db.SaveChanges();
                    }
                    return View();
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}