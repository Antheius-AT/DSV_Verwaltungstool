//-----------------------------------------------------------------------
// <copyright file="IDatabaseService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_ServicesContracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_DataLayer.DataLayerExceptions;

    /// <summary>
    /// Represents an abstract database service capable of connecting to and interacting 
    /// with an underlying database
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Fetches all available books from the database asynchronously.
        /// </summary>
        /// <returns>A task object handling the retrieval of all books and containing said books in its result 
        /// on termination.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the fetching of books fails.
        /// </exception>
        Task<ICollection<Book>> FetchBooksAsync();

        /// <summary>
        /// Fetches all available articles from the database asynchronously.
        /// </summary>
        /// <returns>A task object handling the retrieval of all articles and containing said books in its result.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the fetching of articles fails.
        /// </exception>
        Task<ICollection<Article>> FetchArticlesAsync();

        /// <summary>
        /// Persists a book in the database asynchronously.
        /// </summary>
        /// <param name="book">The book to persist in the database.</param>
        /// <returns>A task object handling the logic of persisting the book and containing a value
        /// indicating whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="book"/> is null.
        /// </exception>
        Task<bool> PersistBookAsync(Book book);

        /// <summary>
        /// Persists an article in the database asynchronously.
        /// </summary>
        /// <param name="article">The article to persist in the database.</param>
        /// <returns>A task object handling the logic of persisting the article and containing a value
        /// indicating whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="article"/> is null.
        /// </exception>
        Task<bool> PersistArticleAsync(Article article);

        /// <summary>
        /// Persists an image asynchronously.
        /// </summary>
        /// <param name="image">The image to persist.</param>
        /// <returns>A task handling the logic of persisting the image and containing
        /// a value indicating whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="image"/> is null.
        /// </exception>
        Task<bool> PersistImageAsync(Image image);

        /// <summary>
        /// Fetches a specified image based on its name.
        /// </summary>
        /// <param name="imageName">The image name to look for.</param>
        /// <returns>A task object handling the logic and containing the resulting
        /// image in its result on termination.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="imageName"/> is null.
        /// </exception>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the database operation failed.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if no image with the specified name could be found.
        /// </exception>
        Task<Image> FetchImageByName(string imageName);

        /// <summary>
        /// Fetches all stored images in the database asynchronously.
        /// </summary>
        /// <returns>A task handling the logic and containing the resulting collection
        /// in its result.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the database operation failed.
        /// </exception>
        Task<ICollection<Image>> FetchImagesAsync();
    }
}
