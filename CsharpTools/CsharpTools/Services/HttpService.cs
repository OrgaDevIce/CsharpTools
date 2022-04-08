using CsharpTools.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CsharpTools.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// This method allows to send Http requests on a url
        /// </summary>
        /// <typeparam name="T">How the content of the response should be deserialized</typeparam>
        /// <param name="url">The address to send the request to</param>
        /// <param name="httpMethod">The Http method (HttpMethod.Get, HttpMethod.Post...)</param>
        /// <param name="body">The body to send (it will then be serialized)</param>
        /// <param name="bearer">The bearer token</param>
        /// <returns>This method returns an HttpResult, containing information about the request and the result</returns>
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

                return httpResult;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                httpResult.ErrorMessage = exception.Message;

                return httpResult;
            }
        }
    }
}
