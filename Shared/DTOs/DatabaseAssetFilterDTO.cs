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
    public class DatabaseAssetFilterDTO
    {
        /// <summary>
        /// Gets or sets the current list type.
        /// </summary>
        public ListType ListType { get; set; }
    }
}
