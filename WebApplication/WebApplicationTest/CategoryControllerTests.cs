using ShopBridgeBLL.Entity;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Xunit;
namespace WebApplicationTest
{
    public class CategoryControllerTests
    {
        readonly HttpClient _client;
        [Fact]
        public async Task CreateCategory()
        {
            CategoryModel category = new CategoryModel()
            {
                Name = "Jwellery",
                IsActive = 1
            };
            var content = new JsonContent(category);
            var result = await _client.PostAsync("/api/Category/CreateCategory", content);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async Task DeleteCategory()
        {
            var result = await _client.GetAsync("/api/Category/DeleteCategory?categoryId=1&userId=1");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async Task GetAllCategories()
        {
            var result = await _client.GetAsync("/api/Category/GetAllCategories");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
