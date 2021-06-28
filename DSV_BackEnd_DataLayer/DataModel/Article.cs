//-----------------------------------------------------------------------
// <copyright file="Article.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer.DataModel
{
    /// <summary>
    /// Represents an article stored in the DSV's database.
    /// </summary>
    public class Article : DatabaseAsset
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
        /// Gets or sets the article's title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the article's editor.
        /// </summary>
        public string Editor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the year in which the article was published.
        /// </summary>
        public int PublicationYear
        {
            get;
            set;
        }
    }
}
