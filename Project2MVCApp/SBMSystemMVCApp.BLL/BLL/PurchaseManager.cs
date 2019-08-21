using Project2.Models.Models;
using Project2.Repository.Repository;
using Project2MVCApp.Models.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository;
        public PurchaseManager()
        {
            _purchaseRepository = new PurchaseRepository();
        }
        public List<Supplier> GetSuppliers()
        {
            return _purchaseRepository.GetSuppliers();
        }
        public List<Product> GetProducts()
        {
            return _purchaseRepository.GetProducts();
        }
        public bool AddPurchase(Purchase purchase)
        {
            return _purchaseRepository.AddPurchase(purchase);
        }
        public int GetAvailableQuantity(Product product)
        {
            return _purchaseRepository.GetAvailableQuantity(product);
        }
        public bool UpdateProduct(Purchase purchase)
        {
            return _purchaseRepository.UpdateProduct(purchase);
        }

        public List<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public Purchase GetById(int id)
        {
            return _purchaseRepository.GetById(id);
        }

        public bool isUpdated(Purchase purchase)
        {
            return _purchaseRepository.isUpdated(purchase);
        }
    }
}
