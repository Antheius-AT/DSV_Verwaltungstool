//-----------------------------------------------------------------------
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
        public SQLServerDatabaseService(IConfiguration configuration, ILogger<SQLServerDatabaseService> logger)
        {
            this.configuration = configuration;
            this.databaseServiceLogger = logger;

            var optionsBuilder = new DbContextOptionsBuilder<DSVDatabaseContext>();
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DSV_DEV_DATABASE"));

            this.dbContext = new DSVDatabaseContext(optionsBuilder.Options);
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
    }
}
