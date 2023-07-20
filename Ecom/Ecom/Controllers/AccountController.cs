using Ecom.DAL;
using Ecom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecom.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userId,string password)
        {
            try
            {
                string salt = string.Empty;
                string PASSWORD = string.Empty;
                string DbPassword = string.Empty;
                string userName = string.Empty;

                bool isUservalid = false;

                using (DbEntities db =new DbEntities())
                {
                    if (userId.Count() > 0)
                    {
                        try
                        {
                            userName = db.users
                                .Where(x => x.userId == userId)
                                .Select(x => x.firstName).FirstOrDefault().ToString() + " " +
                                db.users.Where(x => x.userId == userId).Select(x => x.lastName).FirstOrDefault().ToString();

                            DbPassword = db.users.Where(x => x.userId == userId).Select(x => x.password).FirstOrDefault();
                            salt = db.users.Where(x => x.userId == userId).Select(x => x.salt).FirstOrDefault();

                            HashEncryption hash = new HashEncryption();
                            isUservalid = hash.Decrypt(password, DbPassword, salt);
                            
                            if (isUservalid == true)
                            {
                                TempData["msg"] = "Logged In";
                                //FormsAuthentication.SetAuthCookie(userName,false);
                                Session["user"] = userName;
                                return RedirectToAction("Index","Home", Session["user"]);
                            }
                            else
                            {
                                TempData["msg"] = "Wrong Password";
                                return View();
                            }
                        }
                        catch (Exception ex)
                        {
                            return View($"{ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserDetails data)
        {
            if(ModelState.IsValid)
            {
                using(DbEntities db = new DbEntities())
                {
                    if (data.User.password.Count() > 0)
                    {
                        HashEncryption hash = new HashEncryption();
                        var passwordData = hash.Encrypt(data.User.password);    // item 1 contains password and item 2 contains salt

                        data.User.password = passwordData.Item1;
                        data.User.salt = passwordData.Item2;

                    }
                    db.users.Add(data.User);
                    db.addresses.Add(data.Address);
                    db.contacts.Add(data.Contact);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}