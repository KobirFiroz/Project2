
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
    public class ProductManager
    {       
        ProductRepository _productRepository;
        public ProductManager()
        {
            _productRepository = new ProductRepository();
        }
        public List<Category> GetCategories()
        {
            return _productRepository.GetCategories();
        }
        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }
        public bool IsCodeDuplicate(Product product)
        {
            return _productRepository.IsCodeDuplicate(product);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public bool isUpdated(Product aProduct)
        {
            return _productRepository.isUpdated(aProduct);
        }
    }
}
