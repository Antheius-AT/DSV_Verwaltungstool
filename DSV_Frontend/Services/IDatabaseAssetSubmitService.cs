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
        /// Sends image data to the server to be persisted.
        /// </summary>
        /// <param name="image">The data.</param>
        /// <returns></returns>
        Task<bool> SubmitImageAsync(ImageDataDTO image);
    }
}
