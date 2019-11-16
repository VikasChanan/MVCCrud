using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (CustomerModels cust = new CustomerModels())
            {
                return View(cust.customerdetails.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (CustomerModels ccs = new CustomerModels())
            {
                return View(ccs.customerdetails.Where(x=>x.id== id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(customerdetail customer)
        {
            try
            {
                using (CustomerModels cst = new CustomerModels())
                {
                    cst.customerdetails.Add(customer);
                    cst.SaveChanges();
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (CustomerModels ccs = new CustomerModels())
            {
                return View(ccs.customerdetails.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, customerdetail customer)
        {
            try
            {
                // TODO: Add update logic here
                using (CustomerModels cst = new CustomerModels())
                {
                    cst.Entry(customer).State = EntityState.Modified;
                    cst.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (CustomerModels cmd = new CustomerModels())
            {
                return View( cmd.customerdetails.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (CustomerModels cd = new CustomerModels())
                        //modelname
                {
                    customerdetail customer = cd.customerdetails.Where(x => x.id == id).FirstOrDefault();
                    //tablenmame               searching id from table name
                    cd.customerdetails.Remove(customer);
                    //table name
                    cd.SaveChanges();


                }

                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
