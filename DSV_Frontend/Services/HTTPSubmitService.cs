//-----------------------------------------------------------------------
// <copyright file="HTTPSubmitService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Threading.Tasks;
    using DSV_Frontend.Enums;
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
            var response = await this.resourceRequestService.SubmitResourceAsync<BookDataDTO>($"{this.configuration["BASEURI"]}dataquery/persist/book?token={this.appState.AuthenticationToken}", book, HttpSubmitMethod.Post);

            return response.IsSuccess;
        }

        /// <summary>
        /// Sends article data to the server to be persisted.
        /// </summary>
        /// <param name="article">The data.</param>
        /// <returns></returns>
        public async Task<bool> SubmitArticleAsync(ArticleDataDTO article)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<ArticleDataDTO>($"{this.configuration["BASEURI"]}dataquery/persist/article?token={this.appState.AuthenticationToken}", article, HttpSubmitMethod.Post);

            return response.IsSuccess;
        }

        public async Task<bool> SubmitModifiedBookAsync(int originalAssetID, BookDataDTO book)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<BookDataDTO>($"{this.configuration["BASEURI"]}dataquery/modify/book?bookID={originalAssetID}&token={this.appState.AuthenticationToken}", book, HttpSubmitMethod.Put);

            return response.IsSuccess;

        }

        public async Task<bool> SubmitModifiedArticleAsync(int originalAssetID, ArticleDataDTO article)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync<ArticleDataDTO>($"{this.configuration["BASEURI"]}dataquery/modify/article?articleID={originalAssetID}&token={this.appState.AuthenticationToken}", article, HttpSubmitMethod.Put);

            return response.IsSuccess;

        }
    }
}
