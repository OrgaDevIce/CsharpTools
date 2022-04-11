using CsharpTools.Models;
using CsharpTools.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CsharpTools.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<HttpResult<T>> SendHttpRequest<T>(string url, HttpMethod httpMethod, object body = null, string bearer = "")
        {
            var httpResult = new HttpResult<T>();

            try
            {
                // If the bearer token is not "" we add it in the request header
                if (!string.IsNullOrEmpty(bearer))
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

                // Set the httpMethod and the url
                var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri(url) };

                // If the body is not null we add it in the request content
                if (body != null)
                    httpRequestMessage.Content = JsonContent.Create(body);

                var httpResponse = await _httpClient.SendAsync(httpRequestMessage);

                httpResult = new HttpResult<T>(httpResponse);

                if (httpResponse.IsSuccessStatusCode)
                    httpResult.Content = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                httpResult.ErrorMessage = exception.Message;
            }
            return httpResult;
        }

        public Task<HttpResult> SendHttpRequest(string url, HttpMethod httpMethod, object body = null, string bearer = "")
        {
            throw new NotImplementedException();
        }
    }
}
