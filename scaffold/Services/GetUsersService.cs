using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using scaffold.Models;
using scaffold.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace scaffold.Services
{
    public class GetUsersService
    {
        public static async Task<UserProfileList> GetUsers()
        {
            string key = "1234";
            string url = "http://www.lorireid.co.uk/temp/json2.txt";

            //Make sure developers running this sample replaced the API key
            if (key != "1234")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);

            if (results != null)
            {
                return JsonConvert.DeserializeObject<UserProfileList>(results);
            }
            else
            {
                return null;
            }
        }
    }
}