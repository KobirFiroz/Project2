using Project2.DatabaseContext.DatabaseContext;
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
    public class CategoryRepository
    {
        Project2DbContext db;
        public CategoryRepository()
        {
            db = new Project2DbContext();
        }
        public bool AddCategory(Category category)
        {
            int isExecuted = 0;
            db.Categories.Add(category);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public bool isUpdated(Category category)
        {
            int isExecuted = 0;
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }
        public bool DeleteCategory(Category category)
        {
            int isExecuted = 0;
            var aCategory = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if(aCategory!=null)
            {
                db.Categories.Remove(aCategory);
                isExecuted=db.SaveChanges();
            }
            return isExecuted > 0;
        }

        public Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c=>c.Id==id);
        }

        public List<Category> GetCategories()
        {
            var categories = db.Categories.ToList();
            return categories;
        }
        public bool IsCodeDuplicate(Category category)
        {
            var isDuplicate = false;
            var aCategory = db.Categories.FirstOrDefault(c => c.Code == category.Code);
            if(aCategory!=null)
            {
                isDuplicate = true;
            }
            return isDuplicate;
        }
    }
}
