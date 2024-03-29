﻿//-----------------------------------------------------------------------
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
    using ServiceExceptions;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents an abstract database service capable of connecting to and interacting 
    /// with an underlying database
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Fetches a collection of database assets based on the specified filter.
        /// </summary>
        /// <param name="filter">The specified filter determining which assets to fetch.</param>
        /// <returns>The collection of fetches assets.</returns>
        Task<ICollection<DatabaseAsset>> FetchAssetsAsync(MultipleDatabaseAssetFilterDTO filter);

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
        /// <exception cref="AssetNotFoundException">
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

        /// <summary>
        /// Fetches a book based on its unique ID.
        /// </summary>
        /// <param name="ID">The book's ID.</param>
        /// <returns>A task handling the logic of fetching the book.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if a database error occurred during fetching.
        /// </exception>
        /// <exception cref="AssetNotFoundException">
        /// Is thrown if no book with the ID specified could be found.
        /// </exception>
        Task<Book> FetchBookByID(int ID);

        /// <summary>
        /// Fetches an article based on its unique ID.
        /// </summary>
        /// <param name="ID">The article's ID.</param>
        /// <returns>A task handling the logic of fetching the article.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if a database error occurred during fetching.
        /// </exception>
        /// <exception cref="AssetNotFoundException">
        /// Is thrown if no book with the ID specified could be found.
        /// </exception>
        Task<Article> FetchArticleByID(int ID);

        /// <summary>
        /// Modifies an existing book and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="ID">The ID of the book to modify.</param>
        /// <param name="updatedBook">The updated book definition.</param>
        /// <returns>A task object handling the logic of updating the book definition.</returns>
        Task<bool> ModifyBookAsync(int ID, Book updatedBook);

        /// <summary>
        /// Modifies an existing article and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="ID">The ID of the book to modify.</param>
        /// <param name="updatedArticle">The updated article definition.</param>
        /// <returns>A task object handling the logic of updating the article definition.</returns>
        Task<bool> ModifyArticleAsync(int ID, Article updatedArticle);

        /// <summary>
        /// Modifies an existing image and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="imageName">The name of the image to modify.</param>
        /// <param name="imageData">The base64 encoded image data to replace the old data with.</param>
        /// <returns>A task object handling the logic of updating the image definition.</returns>
        Task<bool> ModifyImageDataAsync(string imageName, string imageData);

        /// <summary>
        /// Persists a user in the database asynchronously.
        /// </summary>
        /// <param name="user">The user to persist.</param>
        /// <returns>A task object handling the persisting of the user.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="user"/> is null.
        /// </exception>
        Task<bool> PersistUserAsync(User user);

        /// <summary>
        /// Retrieves a user asynchronously via its username.
        /// </summary>
        /// <param name="username">The user name of the user to retrieve.</param>
        /// <returns>A task object handling the logic of retrieving the user.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        /// <exception cref="AssetNotFoundException">
        /// Is thrown if the specified user was not found.
        /// </exception>
        Task<User> RetrieveUserAsync(string username);
    }
}
