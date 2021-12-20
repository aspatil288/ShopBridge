using Newtonsoft.Json;
using ShopBridgeBLL.Entity;
using ShopBridgeBLL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeBLL.Service
{
    public class CategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public int CreateCategory(List<CategoryModel> categories, string userId)
        {
            return categoryRepository.CreateCategory(CreateXML(categories), userId);
        }
        public int DeleteCategory(int categoryId, string userId)
        {
            return categoryRepository.DeleteCategory(categoryId, userId);
        }
        public List<CategoryModel> GetAllCategories()
        {
            DataTable dt = categoryRepository.GetAllCategories();
            List<CategoryModel> categories = new List<CategoryModel>();
            categories.AddRange(from dr in System.Data.DataTableExtensions.AsEnumerable(dt)
                                 select new CategoryModel()
                                 {
                                     Id = Convert.ToInt32(dr["id"]) is DBNull ? 0 : Convert.ToInt32(dr["id"]),
                                     Name = Convert.ToString(dr["name"]) is DBNull ? "" : Convert.ToString(dr["name"]),
                                     IsActive = Convert.ToInt32(dr["is_active"]) is DBNull ? 0 : Convert.ToInt32(dr["is_active"])
                                 });
            return categories;
        }
        private string CreateXML(IEnumerable<CategoryModel> categories)
        {
            var serializeData = JsonConvert.SerializeObject(categories);
            return JsonConvert.DeserializeXmlNode("{\"doc\":" + serializeData + "}", "root").InnerXml;
        }
    }
}
