using Project2.BLL.BLL;
using Project2.Models;
using Project2.Models.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        PurchaseAddViewModel purchaseavm;
        PurchaseManager _purchaseManager;
        ProductManager _productManager;
        public PurchaseController()
        {
            _purchaseManager = new PurchaseManager();
            _productManager = new ProductManager();
        }
        [HttpGet]
        public ActionResult Add()
        {
            purchaseavm = new PurchaseAddViewModel();
            var supplierListItem= _purchaseManager.GetSuppliers().Select(s => new SelectListItem()
            { Value = s.Id.ToString(), Text = s.Name }).ToList();
            supplierListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });


            purchaseavm.SupplierListItem = supplierListItem;


            var productListItem = _purchaseManager.GetProducts().Select(p => new SelectListItem()
            { Value = p.Id.ToString(), Text = p.Name }).ToList();
            productListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            purchaseavm.ProductListItem = productListItem;
            return View(purchaseavm);
        }
        [HttpPost]
        public ActionResult Add(PurchaseAddViewModel purchaseavm)
        {
            
            foreach(var purchase in purchaseavm.Purchases)
            {
                purchase.Date = purchaseavm.Date;
                purchase.BillNo = purchaseavm.BillNo;
                purchase.SupplierId = purchaseavm.SupplierId;
               
                _purchaseManager.AddPurchase(purchase);
                _purchaseManager.UpdateProduct(purchase);
            }
            purchaseavm = new PurchaseAddViewModel();
            var supplierListItem = _purchaseManager.GetSuppliers().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name }).ToList();
            supplierListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            purchaseavm.SupplierListItem = supplierListItem;
            var productListItem = _purchaseManager.GetProducts().Select(p => new SelectListItem() { Value = p.Id.ToString(), Text = p.Name }).ToList();
            productListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            purchaseavm.ProductListItem = productListItem;
            return View(purchaseavm);
        }
        public JsonResult GetProduct(int productId)
        {
            var aProduct = _productManager.GetById(productId);            
            return Json(aProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Purchase> purchases;
            purchases = null;
            return View(purchases);
        }

        //[HttpPost]
        //public ActionResult Edit(Purchase purchase)
        //{
        //    var purchases = _purchaseManager.GetAll();
        //    if (purchase.Supplier != null)
        //    {
        //        purchases = purchases.Where(c => c.Supplier.ToLower() == purchase.Supplier.ToLower()).ToList();
        //    }
        //    if (purchase.Supplier != null)
        //    {
        //        purchases = purchases.Where(c => c.Supplier.ToLower().Contains(purchase.Supplier.ToLower())).ToList();
        //    }
        //    if (purchase.Address != null)
        //    {
        //        purchases = purchases.Where(c => c.Address.ToLower().Contains(purchase.Address.ToLower())).ToList();
        //    }
        //    if (purchase.Email != null)
        //    {
        //        purchases = purchases.Where(c => c.Email == purchase.Email).ToList();
        //    }
        //    if (purchase.Contact != null)
        //    {
        //        purchases = purchases.Where(c => c.Contact == purchase.Contact).ToList();
        //    }
        //    return View(purchases);
        //}


        public ActionResult Update(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                var aCustomer = _purchaseManager.GetById(purchase.Id);
                aCustomer.Date = purchase.Date;
                aCustomer.BillNo = purchase.BillNo;
                aCustomer.ExpireDate= purchase.ExpireDate;
                aCustomer.ManufacturedDate = purchase.ManufacturedDate;
                aCustomer.MRP = purchase.MRP;
                aCustomer.ProductId= purchase.ProductId;
                aCustomer.Quantity= purchase.Quantity;
                aCustomer.Remarks = purchase.Remarks;
                aCustomer.SupplierId = purchase.SupplierId;
                aCustomer.UnitPrice = purchase.UnitPrice;
                if (_purchaseManager.isUpdated(aCustomer))
                {
                    ViewBag.SuccessMsg = "Successfully Updated";
                    purchase.Date = "";
                    purchase.BillNo = "";
                    purchase.ExpireDate = "";
                    purchase.ManufacturedDate = "";
                    purchase.MRP =0;
                    purchase.ProductId=0;
                    purchase.Remarks = "";
                    purchase.Quantity = 0;
                    purchase.SupplierId = 0;
                    purchase.UnitPrice = 0;
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
            return View(purchase);
        }

    }
}