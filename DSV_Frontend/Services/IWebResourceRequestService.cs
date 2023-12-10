//-----------------------------------------------------------------------
// <copyright file="IWebResourceRequestService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Threading.Tasks;
    using DSV_Frontend.Data;
    using DSV_Frontend.Enums;

    /// <summary>
    /// Represent a service capable of requesting web resources.
    /// </summary>
    public interface IWebResourceRequestService
    {
        /// <summary>
        /// Gets a resource from a remote endpoint asynchronously.
        /// </summary>
        /// <param name="uri">The uri of the web resource.</param>
        /// <returns>An object containing information about whether or not the request was
        /// a success, as well as any returned data.</returns>
        public Task<WebResourceResponse> GetResourceAsync(string uri);

        /// <summary>
        /// Submits a resource to a remote endpoint asynchronously.
        /// </summary>
        /// <param name="uri">The uri of the remote endpoint.</param>
        /// <returns>An object containing information about whether or not the request was 
        /// a success, as well as any returned data.</returns>
        public Task<WebResourceResponse> SubmitResourceAsync<T>(string uri, T data, HttpSubmitMethod method);
    }
}
