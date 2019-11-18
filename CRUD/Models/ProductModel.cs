using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CRUD.Models
{
    public class ProductModel
    {
        public int Product_id { get; set; }
        [DisplayName("PRODUCT NAME")]
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string ProductName { get; set; }
     
        [DisplayName("Product Description")]
        public string ProductDesc { get; set; }
        [DisplayName("Proquct Quantity")]
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
    }
}