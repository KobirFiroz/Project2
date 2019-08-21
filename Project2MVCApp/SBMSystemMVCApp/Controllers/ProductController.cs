using Project2.BLL.BLL;
using Project2.Models;
using Project2MVCApp.Models.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class ProductController : Controller
    {
        ProductAddViewModel productavm;
        ProductManager _productManager;
        public ProductController()
        {
            _productManager = new ProductManager();
        }
        // GET: Product
        [HttpGet]
        public ActionResult Add()
        {
            productavm = new ProductAddViewModel();
            var categories = _productManager.GetCategories().Select(p => new SelectListItem() {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            categories.Insert(0, new SelectListItem() {
                Value = "",
                Text="Select..."
            });
            productavm.Categories = categories;
            productavm.Products = _productManager.GetProducts();
            return View(productavm);
        }
        [HttpPost]
        public ActionResult Add(ProductAddViewModel productavm)
        {
            var product = new Product();
            if(ModelState.IsValid)
            {
                product.Code = productavm.Code;
                product.Name = productavm.Name;
                product.CategoryId = productavm.CategoryId;
                product.ReorderLevel = productavm.ReorderLevel;
                product.Description = productavm.Description;
                product.AvailableQuantity = 0;
                product.CurrentMRP = 0;
                product.UnitPrice = 0;
                if(_productManager.IsCodeDuplicate(product))
                {
                    ViewBag.FailMsg = "Code is Duplicate";
                }
                else if(_productManager.AddProduct(product))
                {
                    ViewBag.SuccessMsg = "Successfully Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Save Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            var categories = _productManager.GetCategories().Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            categories.Insert(0, new SelectListItem()
            {
                Value = "",
                Text = "Select..."
            });
            productavm.Categories = categories;
            productavm.Products = _productManager.GetProducts();
            return View(productavm);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            productavm = new ProductAddViewModel();
            Product aProduct = _productManager.GetById(id);
            productavm.Code = aProduct.Code;
            productavm.Name = aProduct.Name;
            productavm.CategoryId = aProduct.CategoryId;
            productavm.ReorderLevel = aProduct.ReorderLevel;
            productavm.Description = aProduct.Description;
            var categories = _productManager.GetCategories().Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            categories.Insert(0, new SelectListItem()
            {
                Value = "",
                Text = "Select..."
            });
            productavm.Categories = categories;
            return View(productavm);
        }
        [HttpPost]
        public ActionResult Update(ProductAddViewModel productavm)
        {
            if (ModelState.IsValid)
            {
                var aProduct = _productManager.GetById(productavm.Id);
                aProduct.Name = productavm.Name;
                aProduct.Code = productavm.Code;
                aProduct.CategoryId = productavm.CategoryId;
                aProduct.ReorderLevel = productavm.ReorderLevel;
                aProduct.Description = productavm.Description;
                if (_productManager.isUpdated(aProduct))
                {
                    ViewBag.SuccessMsg = "Successfully Updated";
                    productavm.Name = "";
                    productavm.Code = "";
                    productavm.CategoryId = 0;
                    productavm.ReorderLevel = 0;
                    productavm.Description = "";
                }
                else
                {
                    ViewBag.FailMsg = "Update Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            var categories = _productManager.GetCategories().Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            categories.Insert(0, new SelectListItem()
            {
                Value = "",
                Text = "Select..."
            });
            productavm.Categories = categories;
            return View(productavm);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productManager.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {            
            if(_productManager.DeleteProduct(product))
            {
                ViewBag.SuccessMsg = "Successfully Deleted";
            }else
            {
                ViewBag.FailMsg = "Deletion Failed";
            }
            return View(product);
        }
    }
}