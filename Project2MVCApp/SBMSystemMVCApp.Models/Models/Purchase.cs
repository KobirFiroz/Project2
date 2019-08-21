using Project2.Models.Models;
using Project2MVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Models.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }
        public string BillNo { get; set; }
        public int SupplierId { get;set;}
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }       
        public string ManufacturedDate { get;set;}
        public string ExpireDate { get;set;}
        public int Quantity { get;set;}
        public int UnitPrice { get;set;}
        public int MRP { get;set;}
        public string Remarks { get; set; }
        
    }
}
