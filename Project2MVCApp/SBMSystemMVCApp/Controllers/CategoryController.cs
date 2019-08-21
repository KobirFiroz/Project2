using Project2.Models;
using Project2.BLL.BLL;
using Project2MVCApp.Models.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        // GET: Category
        [HttpGet]
        public ActionResult Add()
        {
            CategoryAddViewModel categoryavm = new CategoryAddViewModel();
            categoryavm.Categories = _categoryManager.GetCategories();
            return View(categoryavm);
        }
        [HttpPost]
        public ActionResult Add(CategoryAddViewModel categoryavm)
        {
            Category category = new Category();
            if(ModelState.IsValid)
            {
                category.Code = categoryavm.Code;
                category.Name = categoryavm.Name;
                if(_categoryManager.IsCodeDuplicate(category))
                {
                    ViewBag.FailMsg = "Code is Duplicate";
                } 
                else if(_categoryManager.AddCategory(category))
                {
                    ViewBag.SuccessMsg = "Saved Successfully";                    
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
            categoryavm.Categories = _categoryManager.GetCategories();
            return View(categoryavm);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Category aCategory = _categoryManager.GetById(id);
            return View(aCategory);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                var aCategory = _categoryManager.GetById(category.Id);
                aCategory.Name = category.Name;
                aCategory.Code = category.Code;
                if (_categoryManager.isUpdated(aCategory))
                {
                    ViewBag.SuccessMsg = "Successfully Updated";
                    category.Name = "";
                    category.Code = "";                    
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
            return View(category);
        }
        public void Delete(int id)
        {
            var category = new Category();
            category.Id = id;
            _categoryManager.DeleteCategory(category);
        }
    }
}