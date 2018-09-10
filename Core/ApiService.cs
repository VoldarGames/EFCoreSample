using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ApiService
    {
        public HttpClient HttpClient;

        public ApiService(string ip)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri($"http://{ip}/EFCoreSample/");
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(TRequest entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error
            };

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var methodUri = "api/values";
            HttpResponseMessage result = null;
            result = await HttpClient.PostAsync(new Uri(methodUri, UriKind.Relative), content);
            
            TResult deserializedObject = default(TResult);
            if (result != null && result?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var postResult = await result.Content.ReadAsStringAsync();
                deserializedObject = JsonConvert.DeserializeObject<TResult>(postResult, jsonSerializerSettings);
            }
            return deserializedObject;
        }
    }
}
