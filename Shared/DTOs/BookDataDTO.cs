//-----------------------------------------------------------------------
// <copyright file="BookDataDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a domain transfer object containing book data.
    /// </summary>
    public class BookDataDTO
    {
        public BookDataDTO()
        {
            this.PublicationYear = DateTime.Now.Year;
        }

        /// <summary>
        /// Gets or sets the book id.
        /// </summary>
        public int AssetID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [Required(ErrorMessage = "Autor darf nicht leer sein")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [Required(ErrorMessage = "Titel darf nicht leer sein")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sub level title.
        /// </summary>
        [Required(ErrorMessage = "Untertitel darf nicht leer sein")]
        public string SubLevelTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's publisher.
        /// </summary>
        [Required(ErrorMessage = "Herausgeber darf nicht leer sein")]
        public string Publisher
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's editor.
        /// </summary>
        [Required(ErrorMessage = "Verlag darf nicht leer sein")]
        public string Editor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location in which the book was published.
        /// </summary>
        [Required(ErrorMessage = "Erscheinungsort darf nicht leer sein")]
        public string PublicationLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the publication year.
        /// </summary>
        [Required(ErrorMessage = "Erscheinungsjahr darf nicht leer sein")]
        [Range(0, 3000, ErrorMessage = "Erscheinungsjahr muss zwischen 0 und 3000 liegen.")]
        public int PublicationYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pages. Pages can either be uncounted (string) 
        /// or counted (integer)
        /// </summary>
        [Required(ErrorMessage = "Seitenanzahl darf nicht leer sein")]
        public string Pages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book's ISBN.
        /// </summary>
        [Required(ErrorMessage = "ISBN darf nicht leer sein")]
        [MinLength(10, ErrorMessage = "ISBN muss mindestens 10 Zeichen lang sein")]
        [MaxLength(13, ErrorMessage = "ISBN darf nicht länger als 13 Zeichen sein")]
        public string ISBN
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the previous storage location of this asset.
        /// </summary>
        [Required(ErrorMessage = "Alte Signatur darf nicht leer sein")]
        public string PreviousStorageLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image data associated with this book.
        /// </summary>
        public string ImageDataBase64Encoded
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
