using CsharpTools.Models;
using CsharpTools.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CsharpTools.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public string BaseUrl { get; set; }

    private bool _byPassCertificate;
    public bool ByPassCertificate
    {
        get => _byPassCertificate;
        set
        {
            if (value)
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
                _httpClient = new HttpClient(httpClientHandler);
                _byPassCertificate = value;
            }
            else
            {
                _httpClient = new HttpClient();
            }
        }
    }

    public HttpService()
    {
        if (_httpClient == null)
            _httpClient = new HttpClient();
    }

    public HttpService(string baseUrl):this()
    {
        BaseUrl = baseUrl;
    }
        
    public async Task<HttpResult<T>> SendHttpRequest<T>(string url, HttpMethod httpMethod, object body = null, string bearer = "")
    {
        var httpResult = new HttpResult<T>();

        try
        {
            var response = await SendRequest(url, httpMethod, body, bearer);

            httpResult = new HttpResult<T>(response);

            if (response.IsSuccessStatusCode)
                httpResult.Content = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            httpResult.ErrorMessage = exception.Message;
        }
        return httpResult;
    }

    public async Task<HttpResult> SendHttpRequest(string url, HttpMethod httpMethod, object body = null, string bearer = "")
    {
        var httpResult = new HttpResult();

        try
        {
            var response = await SendRequest(url, httpMethod, body, bearer);
                
            httpResult = new HttpResult(response);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            httpResult.ErrorMessage = exception.Message;
        }
        return httpResult;
    }

    private async Task<HttpResponseMessage> SendRequest(string url, HttpMethod httpMethod, object body = null, string bearer = "")
    {
        try
        {
            if (!string.IsNullOrEmpty(bearer))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

            // Set the httpMethod and the url
            var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri($"{BaseUrl}{url}") };

            // If the body is not null we add it in the request content
            if (body != null)
                httpRequestMessage.Content = JsonContent.Create(body);

            var response = await _httpClient.SendAsync(httpRequestMessage);

            return response;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return null;
        }
    }
}
