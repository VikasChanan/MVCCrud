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
                ue.users.Add(u);
                ue.SaveChanges();
            }
            return View(); //Always remember to return view when adding [HttpGet][HttpPost] manually inside controller otherwise it will thro error in Actionresult methodname*
            
        }
    }
}