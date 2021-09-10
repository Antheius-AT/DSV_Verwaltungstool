//-----------------------------------------------------------------------
// <copyright file="IDatabaseAssetSubmitService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Threading.Tasks;
    using SharedDefinitions.DTOs;

    public interface IDatabaseAssetSubmitService
    {
        /// <summary>
        /// Sends book data to the server to be persisted.
        /// </summary>
        /// <param name="book">The data.</param>
        /// <returns></returns>
        Task<bool> SubmitBookAsync(BookDataDTO book);

        /// <summary>
        /// Sends article data to the server to be persisted.
        /// </summary>
        /// <param name="article">The data.</param>
        /// <returns></returns>
        Task<bool> SubmitArticleAsync(ArticleDataDTO article);

        /// <summary>
        /// Sends modified book data to the server to be persisted.
        /// </summary>
        /// <param name="originalAssetID">The ID of the original asset.</param>
        /// <param name="book">The data.</param>
        /// <returns></returns>
        Task<bool> SubmitModifiedBookAsync(int originalAssetID, BookDataDTO book);

        /// <summary>
        /// Sends modified article data to the server to be persisted.
        /// </summary>
        /// <param name="originalAssetID">The ID of the original asset.</param>
        /// <param name="article">The data.</param>
        /// <returns></returns>
        Task<bool> SubmitModifiedArticleAsync(int originalAssetID, ArticleDataDTO article);
    }
}
