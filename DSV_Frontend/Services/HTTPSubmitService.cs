//-----------------------------------------------------------------------
// <copyright file="HTTPSubmitService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using DSV_Frontend.Shared;
    using Microsoft.Extensions.Configuration;
    using SharedDefinitions.DTOs;

    public class HTTPSubmitService : IDatabaseAssetSubmitService
    {
        private IWebResourceRequestService resourceRequestService;
        private IConfiguration configuration;
        private AppState appState;

        public HTTPSubmitService(IWebResourceRequestService resourceRequestService, IConfiguration configuration, AppState appState)
        {
            this.resourceRequestService = resourceRequestService;
            this.configuration = configuration;
            this.appState = appState;
        }

        /// <summary>
        /// Sends book data to the server to be persisted.
        /// </summary>
        /// <param name="book">The data.</param>
        /// <returns></returns>
        public async Task<bool> SubmitBookAsync(BookDataDTO book)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<BookDataDTO>($"{this.configuration["BASEURI"]}dataquery/persist/book?token={this.appState.AuthenticationToken}", book);

            return response.IsSuccess;
        }

        /// <summary>
        /// Sends article data to the server to be persisted.
        /// </summary>
        /// <param name="article">The data.</param>
        /// <returns></returns>
        public async Task<bool> SubmitArticleAsync(ArticleDataDTO article)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<ArticleDataDTO>($"{this.configuration["BASEURI"]}dataquery/persist/article?token={this.appState.AuthenticationToken}", article);

            return response.IsSuccess;
        }

        /// <summary>
        /// Sends image data to the server to be persisted.
        /// </summary>
        /// <param name="image">The data.</param>
        /// <returns></returns>
        public async Task<bool> SubmitImageAsync(ImageDataDTO image)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<ImageDataDTO>($"{this.configuration["BASEURI"]}dataquery/persist/image?token={this.appState.AuthenticationToken}", image);

            return response.IsSuccess;
        }
    }
}
