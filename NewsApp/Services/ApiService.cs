using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Services
{
    public class ApiService
    {
        public async Task<Root> GetNews(string category)
        {
            var httpClient = new HttpClient();
          var response= await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?token=370af1a23aa17b2b53b5ec74456c315b&lang=en&topic={category.ToLower()}");
           return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
