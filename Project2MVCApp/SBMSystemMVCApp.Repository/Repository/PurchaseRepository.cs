using Project2.DatabaseContext.DatabaseContext;
using Project2.Models.Models;
using Project2MVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Repository.Repository
{
    public class PurchaseRepository
    {
        Project2DbContext db;
        public PurchaseRepository()
        {
            db = new Project2DbContext();
        }
        public List<Supplier> GetSuppliers()
        {
            var suppliers = db.Suppliers.ToList();
            return suppliers;
        }
        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }             
        public bool AddPurchase(Purchase purchase)
        {
            int isExecuted = 0;
            db.Purchases.Add(purchase);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public int GetAvailableQuantity(Product product)
        {
            
            return 0;
        }
        public bool UpdateProduct(Purchase purchase)
        {
            int isExecuted = 0;
            var aProduct = db.Products.FirstOrDefault(c => c.Id == purchase.ProductId);
            aProduct.AvailableQuantity += purchase.Quantity;
            aProduct.CurrentMRP = purchase.MRP;
            aProduct.UnitPrice = purchase.UnitPrice;
            db.Entry(aProduct).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }

        public List<Purchase> GetAll()
        {
            var purchases = db.Purchases.ToList();
            return purchases;
        }
        public Purchase GetById(int id)
        {
            var purchase = db.Purchases.FirstOrDefault(c => c.Id == id);
            return purchase;
        }

        public bool isUpdated(Purchase purchase)
        {
            int isExecuted = 0;
            db.Entry(purchase).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }


    }
}
