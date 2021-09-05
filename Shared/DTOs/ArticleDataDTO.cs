//-----------------------------------------------------------------------
// <copyright file="ArticleDataDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    public class ArticleDataDTO
    {
        /// <summary>
        /// Gets or sets the asset ID.
        /// </summary>
        public int AssetID
        {
            get;
            set;
        }

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

        /// <summary>
        /// Gets or sets the previous storage location of this asset.
        /// </summary>
        public string PreviousStorageLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection of images associated with this asset.
        /// </summary>
        public string ImageName
        {
            get;
            set;
        }
    }
}
