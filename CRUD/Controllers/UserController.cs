using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using System.Data;



namespace CRUD.Controllers
{
    public class UserController : Controller
    {
        //For login
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginAuthorize(CRUD.Models.user u)
        {
           
            using (UserEntities ues = new UserEntities())
            {
                var getuser = ues.users.Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();
                if(getuser == null)
                {
                    u.loginErrorMessage = "Incorrest Credientials"; ;
                    return View("login", u);
                }
                else
                {
                    Session["UserID"] = getuser.id;
                    return RedirectToAction("Index", "Customer");
                }
            }
                //var sessiondetail = ue.
                
        }
        //Registration Section

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            user u = new user();
            return View(u);
            // user is a class name from user.cs file whilch contains the user table getter and setter
            //we use the object of user class from user.cs to generate object which contain all the fielfname
        }
    
        [HttpPost]
        public ActionResult AddOrEdit(user u)
        {           
            using (UserEntities ue = new UserEntities())
            {
                if (ue.users.Any(x => x.Username == u.Username))
                {
                    ViewBag.WarningMessage = "UserName Already Exist";
                    return View("AddOrEdit");
                }
                ue.users.Add(u);
                ue.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Regisered Successfully";
            return View("AddOrEdit"); 
            //Always remember to return view when adding [HttpGet][HttpPost] manually inside controller otherwise it will thro error in Actionresult methodname*
            
        }
    }
}