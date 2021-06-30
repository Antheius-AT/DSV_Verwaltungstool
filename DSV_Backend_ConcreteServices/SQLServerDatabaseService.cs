﻿//-----------------------------------------------------------------------
// <copyright file="SQLServerDatabaseService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Backend_ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_DataLayer.DataLayerExceptions;
    using DSV_BackEnd_ServicesContracts;
    using DSV_BackEnd_ServicesContracts.ServiceExceptions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Represents a database service using Microsoft SQL Server.
    /// </summary>
    public class SQLServerDatabaseService : IDatabaseService
    {
        /// <summary>
        /// Database context capable of communicating with the underlying SQL Server database.
        /// </summary>
        private DSVDatabaseContext dbContext;

        /// <summary>
        /// Object storing configuration data.
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Logger object capable of logging actions taken by this service.
        /// </summary>
        private ILogger<SQLServerDatabaseService> databaseServiceLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLServerDatabaseService"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object storing connection strings.</param>
        /// <param name="logger">Logger object capable of logging actions.</param>
        public SQLServerDatabaseService(IConfiguration configuration, ILogger<SQLServerDatabaseService> logger, DSVDatabaseContext dbContext)
        {
            this.configuration = configuration;
            this.databaseServiceLogger = logger;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Fetches all available books from the database asynchronously.
        /// </summary>
        /// <returns>A task object handling the retrieval of all books and containing said books in its result 
        /// on termination.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the database operation fails.
        /// </exception>
        public async Task<ICollection<Book>> FetchBooksAsync()
        {
            try
            {
                var result = await this.dbContext.Books.ToArrayAsync();
                this.databaseServiceLogger.LogInformation("Books successfully fetched.");
                return result;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Following error occurred during fetch books operation: {e.Message}");
                throw new DatabaseOperationException("Error during fetching of books.", e);
            }
        }

        /// <summary>
        /// Fetches all available articles from the database asynchronously.
        /// </summary>
        /// <returns>A task object handling the retrieval of all articles and containing said books in its result.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the database operation fails.
        /// </exception>
        public async Task<ICollection<Article>> FetchArticlesAsync()
        {
            try
            {
                var result = await this.dbContext.Articles.ToArrayAsync();
                this.databaseServiceLogger.LogInformation("Articles successfully fetched.");
                return result;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Following error occurred during fetch articles operation: {e.Message}");
                throw new DatabaseOperationException("Error during fetching of articles.", e);
            }
        }

        /// <summary>
        /// Persists a book in the database asynchronously.
        /// </summary>
        /// <param name="book">The book to persist in the database.</param>
        /// <returns>A task object handling the logic of persisting the book and containing a value
        /// indicating whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="book"/> is null.
        /// </exception>
        public async Task<bool> PersistBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book to persist must not be null.");

            try
            {
                await this.dbContext.Books.AddAsync(book);
                await this.dbContext.SaveChangesAsync();
                this.databaseServiceLogger.LogInformation($"Successfully persisted book in the database. Book ID: {book.AssetID}");

                return true;
            }
            catch (Exception)
            {
                this.databaseServiceLogger.LogError($"Could not persist book in database. Book ID: {book.AssetID}");

                return false;
            }
        }

        /// <summary>
        /// Persists an article in the database asynchronously.
        /// </summary>
        /// <param name="article">The article to persist in the database.</param>
        /// <returns>A task object handling the logic of persisting the article and containing a value
        /// indicating whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="article"/> is null.
        /// </exception>
        public async Task<bool> PersistArticleAsync(Article article)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article), "Article to persist must not be null.");

            try
            {
                await this.dbContext.Articles.AddAsync(article);
                await this.dbContext.SaveChangesAsync();
                this.databaseServiceLogger.LogInformation($"Successfully persisted article in the database. Article ID: {article.AssetID}");

                return true;
            }
            catch (Exception)
            {
                this.databaseServiceLogger.LogError($"Could not persist article into the database. Article ID: {article.AssetID}");

                return false;
            }
        }

        /// <summary>
        /// Persists an image in the database asynchronously.
        /// </summary>
        /// <param name="image">The image to persist.</param>
        /// <returns>A task handling the logic and containing a value indicating
        /// whether the operation was a success in its result.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="image"/> is null.
        /// </exception>
        public async Task<bool> PersistImageAsync(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image must not be null.");

            try
            {
                await this.dbContext.Images.AddAsync(image);
                await this.dbContext.SaveChangesAsync();
                this.databaseServiceLogger.LogInformation("Image successfully uploaded.");

                return true;
            }
            catch (Exception)
            {
                this.databaseServiceLogger.LogInformation("Image upload failed.");

                return false;
            }
        }

        /// <summary>
        /// Fetches all stored images in the database asynchronously.
        /// </summary>
        /// <returns>A task handling the logic and containing the resulting collection
        /// in its result.</returns>
        /// <exception cref="DatabaseOperationException">
        /// Is thrown if the database operation failed.
        /// </exception>
        public async Task<ICollection<Image>> FetchImagesAsync()
        {
            try
            {
                var result = await this.dbContext.Images.ToArrayAsync();
                this.databaseServiceLogger.LogInformation("Successfully fetched available images.");

                return result;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogInformation($"The following error occurred during fetching of all images: {e.Message}");
                throw new DatabaseOperationException("Database error during fetching of images", e);
            }
        }

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
        public async Task<Image> FetchImageByName(string imageName)
        {
            if (imageName == null)
                throw new ArgumentNullException(nameof(imageName), "Image name must not be null.");

            try
            {
                var result = await this.dbContext.Images.FirstOrDefaultAsync(p => p.ImageName == imageName) ?? throw new AssetNotFoundException();
                this.databaseServiceLogger.LogInformation($"Image with name {imageName} successfully fetched.");

                return result;
            }
            catch (AssetNotFoundException)
            {
                this.databaseServiceLogger.LogInformation($"Image with name {imageName} could not be found.");
                throw;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError("Database error occurred during fetching of single image", e);
                throw;
            }
        }

        /// <summary>
        /// Fetches a single book using its unique ID.
        /// </summary>
        /// <param name="ID">The book's ID.</param>
        /// <returns>A task object handling the logic of fetching the book.</returns>
        /// <exception cref="AssetNotFoundException">
        /// Is thrown if no book could be found with the specified ID.
        /// </exception>
        public async Task<Book> FetchBookByID(int ID)
        {
            try
            {
                var result = await this.dbContext.Books.FindAsync(ID) ?? throw new AssetNotFoundException();
                this.databaseServiceLogger.LogInformation($"Book with ID: {ID} was successfully fetched.");

                return result;
            }
            catch (AssetNotFoundException)
            {
                this.databaseServiceLogger.LogInformation($"Book with ID: {ID} was not found.");
                throw;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Database error occurred during fetching of book with ID: {ID}", e);
                throw;
            }
        }

        /// <summary>
        /// Fetches a single article using its unique ID.
        /// </summary>
        /// <param name="ID">The article's ID.</param>
        /// <returns>A task object handling the logic of fetching the article.</returns>
        /// <exception cref="AssetNotFoundException">
        /// Is thrown if the asset could not be found.
        /// </exception>
        public async Task<Article> FetchArticleByID(int ID)
        {
            try
            {
                var result = await this.dbContext.Articles.FindAsync(ID) ?? throw new AssetNotFoundException();
                this.databaseServiceLogger.LogInformation($"Article with ID: {ID} was successfully fetched.");

                return result;
            }
            catch (AssetNotFoundException)
            {
                this.databaseServiceLogger.LogInformation($"Article with ID: {ID} was not found.");
                throw;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Database error occurred during fetching of article with ID: {ID}", e);
                throw;
            }
        }

        /// <summary>
        /// Modifies an existing book and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="ID">The ID of the book to modify.</param>
        /// <param name="updatedBook">The updated book definition.</param>
        /// <returns>A task object handling the logic of updating the book definition.</returns>
        public async Task<bool> ModifyBookAsync(int ID, Book updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentNullException(nameof(updatedBook), "Updated book must not be null.");

            try
            {
                var toModify = await this.dbContext.Books.FirstOrDefaultAsync(p => p.AssetID == ID) ?? throw new AssetNotFoundException();
                
                this.UpdateBookData(toModify, updatedBook);
                await this.dbContext.SaveChangesAsync();
                this.databaseServiceLogger.LogInformation($"Successfully replaced book definition for book with ID: {ID}", toModify, updatedBook);

                return true;
            }
            catch (AssetNotFoundException)
            {
                this.databaseServiceLogger.LogInformation($"Tried to modify book with ID: {ID}, but the asset was not found.");
                return false;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Error occurred during modifying book with ID: {ID}", e);
                throw;
            }
        }

        /// <summary>
        /// Modifies an existing article and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="ID">The ID of the book to modify.</param>
        /// <param name="updatedArticle">The updated article definition.</param>
        /// <returns>A task object handling the logic of updating the article definition.</returns>
        public async Task<bool> ModifyArticleAsync(int ID, Article updatedArticle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies an existing image and overwrites its data with newly specified data.
        /// </summary>
        /// <param name="imageName">The name of the image to modify.</param>
        /// <param name="imageData">The base64 encoded image data to replace the old data with.</param>
        /// <returns>A task object handling the logic of updating the image definition.</returns>
        public async Task<bool> ModifyImageDataAsync(string imageName, string imageData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the book with the specified ID from the database.
        /// </summary>
        /// <param name="bookID">The ID of the book to delete.</param>
        /// <returns>A task handling the logic of deletion and returning whether the operation was a success.</returns>
        public async Task<bool> DeleteBookAsync(int bookID)
        {
            try
            {
                var toDelete = await this.dbContext.Books.FindAsync(bookID) ?? throw new AssetNotFoundException();

                this.dbContext.Books.Remove(toDelete);
                await this.dbContext.SaveChangesAsync();

                this.databaseServiceLogger.LogInformation($"Successfully deleted book with ID: {bookID}.");

                return true;
            }
            catch (AssetNotFoundException)
            {
                this.databaseServiceLogger.LogInformation($"Could not find book with ID {bookID} to delete.");
                return false;
            }
            catch (Exception e)
            {
                this.databaseServiceLogger.LogError($"Error occurred during deletion of book with ID: {bookID}", e);
                throw;
            }
        }

        /// <summary>
        /// Overwrites an old book <paramref name="toModify"/> with a new definition <paramref name="updatedBook"/>.
        /// </summary>
        /// <param name="toModify">The book to modify.</param>
        /// <param name="updatedBook">The new book to replace the old one.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="updatedBook"/> or <paramref name="toModify"/> are null.
        /// </exception>
        private void UpdateBookData(Book toModify, Book updatedBook)
        {
            if (toModify == null)
                throw new ArgumentNullException(nameof(toModify), "Book to modify must not be null.");

            if (updatedBook == null)
                throw new ArgumentNullException(nameof(updatedBook), "Book to update must not be null.");

            toModify.Author = updatedBook.Author;
            toModify.Editor = updatedBook.Editor;
            toModify.ImageName = updatedBook.ImageName;
            toModify.ISBN = updatedBook.ISBN;
            toModify.Pages = updatedBook.Pages;
            toModify.PreviousStorageLocation = updatedBook.PreviousStorageLocation;
            toModify.PublicationLocation = updatedBook.PublicationLocation;
            toModify.PublicationYear = updatedBook.PublicationYear;
            toModify.Publisher = updatedBook.Publisher;
            toModify.SubLevelTitle = updatedBook.SubLevelTitle;
            toModify.Title = updatedBook.Title;
        }
    }
}
