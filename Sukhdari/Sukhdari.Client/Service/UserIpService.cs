using Models;
using Sukhdari.Client.Service.IService;
using System.Net.Http.Json;

namespace Sukhdari.Client.Service
{
    public class UserIpService : IUserIpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public UserIpService(IHttpClientFactory httpClientFactory,HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClient;

        }
        public async Task<UserIpDTO> GetUserIPAsync()
        {
            var client = _httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<UserIpDTO>("/");
        }

        public async void StoreIp(UserIpDTO userIpDTO)
        {
            // var body=JsonConvert.SerializeObject(userIpDTO);
            // var content=new StringContent(body,System.Text.Encoding.UTF8,"application/json");
            var response=await _httpClient.PostAsJsonAsync<UserIpDTO>("api/UserIp/Create",userIpDTO);
            
        }
    }
}
