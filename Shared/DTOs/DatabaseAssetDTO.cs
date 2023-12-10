//-----------------------------------------------------------------------
// <copyright file="DatabaseAssetDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    using System.Collections.Generic;
    using Enumerations;

    /// <summary>
    /// Represent a DTO containing database asset information.
    /// </summary>
    public class DatabaseAssetDTO
    {
        /// <summary>
        /// Gets the list type contained in this DTO.
        /// </summary>
        public ListType ListType { get; set; }

        /// <summary>
        /// Gets or sets the asset ID.
        /// </summary>
        public int AssetID
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
        public string ImageDataBase64Encoded
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

        public string AdditionalComments
        {
            get;
            set;
        }
    }
}
