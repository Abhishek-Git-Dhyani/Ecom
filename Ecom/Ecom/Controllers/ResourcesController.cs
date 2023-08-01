using Ecom.DAL;
using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    return RedirectToAction("Stores", "Resources");
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
        //[HttpGet]
        //public ActionResult deleteStore()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult deleteStore(int ID)
        {
            try
            {
                Store selected_store_detail = new Store();
                using (DbEntities db = new DbEntities())
                {
                    selected_store_detail = db.Stores.FirstOrDefault(x => x.storeId == ID);
                }
                return View(selected_store_detail);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult deleteStore(Store storeDetail)
        {
            try
            {

                using(DbEntities db = new DbEntities())
                {
                    //db.Entry(storeDetail).State = System.Data.Entity.EntityState.Deleted;
                    //db.SaveChanges();

                    var store_detail_if_available = db.Stores
                        .FirstOrDefault(x => x.storeId == storeDetail.id);

                    db.Stores.Remove(store_detail_if_available);
                    db.SaveChanges();

                }
                return RedirectToAction("Stores");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult editStore(int ID)
        {
            try
            {
                Store selected_store_detail = new Store();
                using(DbEntities db = new DbEntities())
                {
                    selected_store_detail = db.Stores
                        .FirstOrDefault(x => x.storeId == ID);
                }
                return View(selected_store_detail);
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult editStore([Bind(Include = "id,storeId,CenterCode,Address,city,state,pincode")]Store storeDetail)
        {
            try
            {
                Store select_store_detail = new Store();
                if(ModelState.IsValid)
                {
                    using (DbEntities db = new DbEntities())
                    {
                        select_store_detail = db.Stores.FirstOrDefault(x => x.storeId == storeDetail.id);

                        select_store_detail.storeId = storeDetail.storeId;
                        select_store_detail.Address = storeDetail.Address;
                        select_store_detail.city = storeDetail.city;
                        select_store_detail.CenterCode = storeDetail.CenterCode;
                        select_store_detail.state = storeDetail.state;

                        db.SaveChanges();
                        
                    }
                }
                return RedirectToAction("Stores");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}