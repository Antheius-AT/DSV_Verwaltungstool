//-----------------------------------------------------------------------
// <copyright file="IAssetFetchingService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents a service used for fetching database assets from a remote endpoint.
    /// </summary>
    public interface IAssetFetchingService
    {
        /// <summary>
        /// Fetches database assets based on a given filter.
        /// </summary>
        /// <param name="filter">The applied filter.</param>
        /// <returns>The fetched assets.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="filter"/> is null.
        /// </exception>
        Task<IEnumerable<DatabaseAssetDTO>> FetchAssets(DatabaseAssetFilterDTO filter);
    }
}
