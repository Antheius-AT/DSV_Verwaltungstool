//-----------------------------------------------------------------------
// <copyright file="Book.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer.DataModel
{
    /// <summary>
    /// Represent a book stored in the DSV's database.
    /// </summary>
    public class Book : DatabaseAsset
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sub level title.
        /// </summary>
        public string SubLevelTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's publisher.
        /// </summary>
        public string Publisher
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's editor.
        /// </summary>
        public string Editor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location in which the book was published.
        /// </summary>
        public string PublicationLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the publication year.
        /// </summary>
        public int PublicationYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pages. Pages can either be uncounted (string) 
        /// or counted (integer)
        /// </summary>
        public string Pages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's ISBN.
        /// </summary>
        public string ISBN
        {
            get;
            set;
        }
    }
}
