using ShopBridgeBLL.Entity;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Xunit;

namespace WebApplicationTest
{
    public class InventoryControllerTests
    {
        readonly HttpClient _client;
        [Fact]
        public async Task GetAllInventories()
        {
            var result = await _client.GetAsync("/api/Inventory/GetAllInventories");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async Task GetInventoryByCategory_CategoryId()
        {
            var result = await _client.GetAsync("/api/Inventory/GetInventoryByCategory?categoryId=1");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async Task GetInventoryById_InventoryId()
        {
            var result = await _client.GetAsync("/api/Inventory/GetInventoryById?inventoryId=1");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
