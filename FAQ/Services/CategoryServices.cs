using FAQ.Models;
using FAQ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAQ.Services
{
    public class CategoryServices
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public List<Categories> GetCategoryBySelectedItem(int id)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                categories= categoryRepository.GetCategories(id);
            }
            catch { }
            return categories;
        }

        internal Categories GetCategoryByID(int categoryId)
        {
            Categories category = new Categories();
            category = categoryRepository.GetCategory(categoryId);
            return category;
        }
    }
}