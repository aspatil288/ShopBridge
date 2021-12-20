using ShopBridgeBLL.Entity;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Xunit;

namespace WebApplicationTest
{
    public class LoginControllerTests
    {
        readonly HttpClient _client;
        [Fact]
        public async Task AuthenticateUser_UserName_Password()
        {
            UserModel user = new UserModel()
            {
                UserName = "Admin",
                Password = "admin@123"

            };
            var content = new JsonContent(user);
            var result = await _client.PostAsync("/api/Login/AuthenticateUser",content);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}