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
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager;
        public SupplierController()
        {
            _supplierManager = new SupplierManager();
        }
        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Supplier());
        }
        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.IsCodeDuplicate(supplier))
                {
                    ViewBag.FailMsg = "Code is Duplicate";
                    return View(supplier);
                }
                if (_supplierManager.Add(supplier))
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
            return View(supplier);
        }
        [HttpGet]
        public ActionResult Search()
        {
            SupplierSearchViewModel suppliersvm = new SupplierSearchViewModel();
            suppliersvm = null;
            return View(suppliersvm);
        }
        [HttpPost]
        public ActionResult Search(SupplierSearchViewModel suppliersvm)
        {
            var suppliers = _supplierManager.GetAll();
            if (suppliersvm.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code == suppliersvm.Code).ToList();
            }
            if (suppliersvm.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(suppliersvm.Name.ToLower())).ToList();
            }
            if (suppliersvm.Address != null)
            {
                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(suppliersvm.Address.ToLower())).ToList();
            }
            if (suppliersvm.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email == suppliersvm.Email).ToList();
            }
            if (suppliersvm.Contact != null)
            {
                suppliers = suppliers.Where(c => c.Contact == suppliersvm.Contact).ToList();
            }
            suppliersvm.Suppliers = suppliers;
            return View(suppliersvm);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            List<Supplier> suppliers;
            suppliers = null;
            return View(suppliers);
        }
        [HttpPost]
        public ActionResult Edit(SupplierSearchViewModel suppliersvm)
        {
            var suppliers = _supplierManager.GetAll();
            if (suppliersvm.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.ToLower() == suppliersvm.Code.ToLower()).ToList();
            }
            if (suppliersvm.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(suppliersvm.Name.ToLower())).ToList();
            }
            if (suppliersvm.Address != null)
            {
                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(suppliersvm.Address.ToLower())).ToList();
            }
            if (suppliersvm.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email == suppliersvm.Email).ToList();
            }
            if (suppliersvm.Contact != null)
            {
                suppliers = suppliers.Where(c => c.Contact == suppliersvm.Contact).ToList();
            }
            return View(suppliers);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Supplier aSupplier = _supplierManager.GetById(id);
            return View(aSupplier);
        }
        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var aSupplier = _supplierManager.GetById(supplier.Id);
                aSupplier.Name = supplier.Name;
                aSupplier.Address = supplier.Address;
                aSupplier.Email = supplier.Email;
                aSupplier.Contact = supplier.Contact;
                aSupplier.ContactPerson = supplier.ContactPerson;
                aSupplier.Code = supplier.Code;
                if (_supplierManager.isUpdated(aSupplier))
                {
                    ViewBag.SuccessMsg = "Successfully Updated";
                    supplier.Name = "";
                    supplier.Code = "";
                    supplier.Address = "";
                    supplier.Email = "";
                    supplier.Contact = "";
                    supplier.ContactPerson = "";
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
            return View(supplier);
        }

    }
}