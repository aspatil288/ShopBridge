using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Utility
{
    public class JsonContent :StringContent
    {
        public JsonContent(object value):base(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
        {

        }
    }
}
