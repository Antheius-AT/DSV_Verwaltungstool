//-----------------------------------------------------------------------
// <copyright file="DSVDatabaseContext.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer
{
    using DSV_BackEnd_DataLayer.DataModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a database context used to connect to the DSV database.
    /// </summary>
    public class DSVDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DSVDatabaseContext"/> class.
        /// </summary>
        /// <param name="options">The options used for the database context.</param>
        public DSVDatabaseContext(DbContextOptions<DSVDatabaseContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the stored books.
        /// </summary>
        public DbSet<Book> Books
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stored articles.
        /// </summary>
        public DbSet<Article> Articles
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stored images.
        /// </summary>
        public DbSet<Image> Images
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stored users.
        /// </summary>
        public DbSet<User> Users
        {
            get;
            set;
        }
    }
}
