//-----------------------------------------------------------------------
// <copyright file="HttpRequestService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using DSV_Frontend.Data;

    /// <summary>
    /// Represent a service capable of requesting web resources via http.
    /// </summary>
    public class HttpRequestService : IWebResourceRequestService
    {
        /// <summary>
        /// Client for issuing HTTP requests.
        /// </summary>
        private HttpClient httpClient;

        public HttpRequestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WebResourceResponse> GetResourceAsync(string uri)
        {
            WebResourceResponse response;

            var httpResponse = await this.httpClient.GetAsync(uri);

            if (!httpResponse.IsSuccessStatusCode)
                response = new WebResourceResponse(false, null);
            else
            {
                var data = await httpResponse.Content.ReadAsStringAsync();
                response = new WebResourceResponse(true, data);
            }

            return response;
        }

        public async Task<WebResourceResponse> SubmitResourceAsync<T>(string uri, T data)
        {
            WebResourceResponse resourceResponse;
            var requestResponse = await this.httpClient.PostAsJsonAsync(uri, data);

            if (!requestResponse.IsSuccessStatusCode)
                resourceResponse = new WebResourceResponse(false, null);
            else
                resourceResponse = new WebResourceResponse(true, await requestResponse.Content.ReadAsStringAsync());

            return resourceResponse;
        }
    }
}
