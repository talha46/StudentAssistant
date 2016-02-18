using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Student_Assistant_App.Models;

namespace Student_Assistant_App.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (UserDBContext db = new UserDBContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount acc)
        {
            if(ModelState.IsValid)
            {
                using (UserDBContext db = new UserDBContext())
                {
                    db.userAccount.Add(acc);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = acc.FirstName + " " + acc.LastName + " Successfully Registered!";
            }
            return View();
        }

        //Login get method
        public ActionResult Login()
        {
            return View();
        }

        //Login post method
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (UserDBContext db = new UserDBContext())
            {
                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password);

                if(usr !=null)
                {
                    if(usr.FirstName.ToString().Contains("parent") || usr.FirstName.ToString().Contains("Parent"))
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["FirstName"] = usr.FirstName.ToString();
                        Session["LastName"] = usr.LastName.ToString();
                        return RedirectToAction("ParentView");
                    }

                    if (usr.Email.ToString().Equals("chaudary.talha@gmail.com", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["FirstName"] = usr.FirstName.ToString();
                        return RedirectToAction("AdminView");
                    }
                    else 
                    if(usr.Email.ToString().Equals("mustafa61@gmail.com", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["FirstName"] = usr.FirstName.ToString();
                        return RedirectToAction("Accountant");
                    }
                    else
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Email"] = usr.Email.ToString();
                        Session["FirstName"] = usr.FirstName.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password!");
                }
            }

            return View();
        }


        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ParentView()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult AdminView()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Accountant()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}