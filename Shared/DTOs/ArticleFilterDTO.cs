//-----------------------------------------------------------------------
// <copyright file="ArticleFilterDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    /// <summary>
    /// Represent a filter containing properties that articles are filterable by.
    /// </summary>
    public class ArticleFilterDTO
    {
        /// <summary>
        /// Gets or sets the author used for filtering.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title used for filtering.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the editor used for filtering.
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// Gets or sets the publication year used for filtering.
        /// </summary>
        public int PublicationYear { get; set; }
    }
}
