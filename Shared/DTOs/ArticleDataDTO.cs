//-----------------------------------------------------------------------
// <copyright file="ArticleDataDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Autor darf nicht leer sein")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the article's title.
        /// </summary>
        [Required(ErrorMessage = "Titel darf nicht leer sein")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the article's editor.
        /// </summary>
        [Required(ErrorMessage = "Verlag darf nicht leer sein")]
        public string Editor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the year in which the article was published.
        /// </summary>
        [Required]
        [Range(0, 3000, ErrorMessage = "Erscheinungsjahr muss definiert sein und zwischen 0 und 3000 liegen.")]
        public int PublicationYear
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
        /// Gets or sets the image data associated with this article.
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
