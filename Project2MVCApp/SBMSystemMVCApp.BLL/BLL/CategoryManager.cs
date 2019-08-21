
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
    public class CategoryManager
    {
        CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }
        public bool AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }
        public bool isUpdated(Category category)
        {
            return _categoryRepository.isUpdated(category);
        }
        public bool DeleteCategory(Category category)
        {
            return _categoryRepository.DeleteCategory(category);
        }
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public bool IsCodeDuplicate(Category category)
        {
            return _categoryRepository.IsCodeDuplicate(category);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
