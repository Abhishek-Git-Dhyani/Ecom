using Ecom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronPdf;

namespace Ecom.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet]
        public ActionResult GetReport(string userId)
        {
            try
            {
                using(DbEntities db = new DbEntities())
                {
                    var user = db.userReports.FirstOrDefault(x=>x.userId == userId).CBC_Report;

                    var Renderer = new HtmlToPdf();

                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
            //var Renderer = new HtmlToPdf();
            ////Renderer = Renderer.
            //return View();
        }
    }
}