using ShopBridgeBLL.Entity;
using ShopBridgeBLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : Controller
    {
        [HttpPost]
        [Route("CreateCategory")]
        public int CreateCategory(List<CategoryModel> category, string userId)
        {
            CategoryService categoryService = new CategoryService();
            int result;
            try
            {
                result = categoryService.CreateCategory(category, userId);
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        [HttpGet]
        [Route("DeleteCategory")]
        public int DeleteCategory(int categoryId, string userId)
        {
            CategoryService categoryService = new CategoryService();
            int result;
            try
            {
                result = categoryService.DeleteCategory(categoryId, userId);
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public List<CategoryModel> GetAllCategories()
        {
            CategoryService categoryService = new CategoryService();
            List<CategoryModel> categories;
            try
            {
                categories = categoryService.GetAllCategories();
            }
            catch (Exception ex)
            {
                categories = new List<CategoryModel>();
            }
            return categories;
        }

    }
}
