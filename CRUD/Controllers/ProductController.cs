/*This Module ie"Customer" is created with out using c# MVC Entity Frame Work.
 Its a plain mvc using pure dataTable Queries
 Creator Name: "Vikas R Chanan"
 Date: 18 November 2019
 Description: first time learned C# MVC*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        string ConnectionString = @"Data Source=DESKTOP-4GG7BSD\SQLEXPRESS;Initial Catalog=Customer;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: Product
        public ActionResult ViewProductDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            { 
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from ProductDetails", con);
                sda.Fill(dt);
            }
                return View(dt);
        }
  
        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel pm)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "insert into ProductDetails values(@ProductName,@ProductDesc,@ProductQuantity,@Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", pm.ProductName);
                cmd.Parameters.AddWithValue("@ProductDesc", pm.ProductDesc);
                cmd.Parameters.AddWithValue("@ProductQuantity",pm.ProductQuantity);
                cmd.Parameters.AddWithValue("@Price",pm.Price);
                cmd.ExecuteNonQuery();
                
    }
                return RedirectToAction("ViewProductDetails");
            
         
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel pm = new ProductModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "Select * from ProductDetails where Product_id = @Productid";
                SqlDataAdapter dr = new SqlDataAdapter(query,con);
                dr.SelectCommand.Parameters.AddWithValue("@Productid", id);
                dr.Fill(dt);
            } 
            if(dt.Rows.Count == 1)
            {
                pm.Product_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                pm.ProductName = dt.Rows[0][1].ToString();
                pm.ProductDesc = dt.Rows[0][2].ToString();
                pm.ProductQuantity = Convert.ToInt32(dt.Rows[0][3].ToString());
                pm.Price = Convert.ToDecimal(dt.Rows[0][4].ToString());
                return View(pm);
            }     
            else
            {
                return RedirectToAction("ViewProductDe" +
                    "tails");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel pm)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "Update ProductDetails set ProductName = @ProductName, ProductDesc = @ProductDesc, ProductQuantity = @ProductQuantity, Price = @Price where Product_id = @Product_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Product_id", pm.Product_id);
                cmd.Parameters.AddWithValue("@ProductName", pm.ProductName);
                cmd.Parameters.AddWithValue("@ProductDesc", pm.ProductDesc);
                cmd.Parameters.AddWithValue("@ProductQuantity", pm.ProductQuantity);
                cmd.Parameters.AddWithValue("@Price", pm.Price);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("ViewProductDetails");


        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "Delete from ProductDetails where Product_id = @Product_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Product_id", id);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("ViewProductDetails");
        }  
    }
}
