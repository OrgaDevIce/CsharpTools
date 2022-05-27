using CsharpTools.Models;

namespace CsharpTools.Services.Interfaces;

public interface IHttpService
{
    /// <summary>
    /// This method allows to send Http requests on a url and get the body
    /// </summary>
    /// <typeparam name="T">How the content of the response should be deserialized</typeparam>
    /// <param name="url">The address to send the request to</param>
    /// <param name="httpMethod">The Http method (HttpMethod.Get, HttpMethod.Post...)</param>
    /// <param name="body">The body to send (it will then be serialized)</param>
    /// <param name="bearer">The bearer token</param>
    /// <returns>This method returns an HttpResult, containing information about the request and the result</returns>
    Task<HttpResult<T>> SendHttpRequest<T>(string url, HttpMethod httpMethod, object body = null, string bearer = "");

    /// <summary>
    /// This method allow to send Http request without getting the body
    /// </summary>
    /// <param name="url">The address to send the request to</param>
    /// <param name="httpMethod">The Http method (HttpMethod.Get, HttpMethod.Post...)</param>
    /// <param name="body">The body to send (it will then be serialized)</param>
    /// <param name="bearer">The bearer token</param>
    /// <returns>This method returns an HttpResult, containing information about the request and the result</returns>
    Task<HttpResult> SendHttpRequest(string url, HttpMethod httpMethod, object body = null, string bearer = "");

    /// <summary>
    /// Set the base url, this url will be added before each calls
    /// </summary>
    string BaseUrl { get; set; }
}
