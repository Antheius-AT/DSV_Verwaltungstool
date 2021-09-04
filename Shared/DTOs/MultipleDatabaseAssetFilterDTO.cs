//-----------------------------------------------------------------------
// <copyright file="DatabaseAssetFilterDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    using Enumerations;

    /// <summary>
    /// Represents a filter used for filtering data in the backend.
    /// </summary>
    public class MultipleDatabaseAssetFilterDTO
    {
        /// <summary>
        /// Gets or sets the current list type.
        /// </summary>
        public ListType ListType { get; set; }

        /// <summary>
        /// Gets or sets a filter containing properties to filter for in regards to books.
        /// </summary>
        public BookFilterDTO BookFilter { get; set; }

        /// <summary>
        /// Gets or sets a filter containing properties to filter for in regards to articles.
        /// </summary>
        public ArticleFilterDTO ArticleFilter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore or check for further filtering
        /// criteria, apart from list type.
        /// </summary>
        public bool NoFurtherFilteringRequested { get; set; }
    }
}
