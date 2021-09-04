//-----------------------------------------------------------------------
// <copyright file="SingleDatabaseAssetFilterDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    using SharedDefinitions.Enumerations;

    public class SingleDatabaseAssetFilterDTO
    {
        /// <summary>
        /// Gets or sets the current list type.
        /// </summary>
        public ListType ListType { get; set; }

        /// <summary>
        /// Gets or sets the id used for filtering.
        /// </summary>
        public int ID { get; set; }
    }
}
