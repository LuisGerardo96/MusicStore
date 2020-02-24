using MusicStore.Login;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MusicStoreEntities())
                {
                    User user = context.Users
                                       .Where(u => u.UserId == model.UserId && u.Password == model.Password)
                                       .FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message("Invalid User Name or Password");
                        return View(model);
                    }
                }
            }
            else
            {
               
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
           string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
              // Email Verification
              string userName = Isuserexist(model.UserId);
              if (!string.IsNullOrEmpty(userName))
              {
                 ViewBag.Message ="Sorry: Email already Exists";
                 return View(model);
              }

              //Save User Data 
              using (var Context = new MusicStoreEntities())
              {
                 var user = new User()
                 {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    Password = model.Password,
                    RoleId = 2,
                 };

                 Context.Users.Add(user);
                 Context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                 
              }
            }
            else
            {
               messageRegistration = "Something Wrong!";
            }
               ViewBag.Message = messageRegistration;
               return View(model);
        }

        [NonAction]
        public string Isuserexist(string UserId)
        {
            using (var Context = new MusicStoreEntities())
            {
                string username = (from u in Context.Users
                                   where string.Compare(UserId, u.UserId) == 0
                                   select u.UserId).FirstOrDefault();
                return !string.IsNullOrEmpty(username) ? username : string.Empty;
            }
        }
    }
}