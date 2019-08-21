using Project2.Models.Models;
using Project2MVCApp.Models.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Models
{
    public class PurchaseAddViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }
        public string BillNo { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Display(Name ="Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ManufacturedDate { get; set; }
        public string ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        [Display(Name = "New MRP (TK)")]
        public int MRP { get; set; }
        public string Remarks { get; set; } 
        public IEnumerable<SelectListItem> SupplierListItem { get; set; }
        public IEnumerable<SelectListItem> ProductListItem { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}