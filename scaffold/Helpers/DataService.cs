using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using scaffold.Models;

namespace scaffold.Helpers
{
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }

            return data;
        }
    }
}
