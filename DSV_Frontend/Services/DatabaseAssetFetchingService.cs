//-----------------------------------------------------------------------
// <copyright file="IDTOMappingService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DSV_Frontend.Shared;
    using Microsoft.Extensions.Configuration;
    using SharedDefinitions.DTOs;
    using SharedDefinitions.Services;

    /// <summary>
    /// Represent a service capable of fetching assets from the database.
    /// </summary>
    public class DatabaseAssetFetchingService : IAssetFetchingService
    {
        /// <summary>
        /// Represents a service capable of requesting resources from a remote endpoint.
        /// </summary>
        private IWebResourceRequestService resourceRequestService;

        /// <summary>
        /// Configuration object storing information such as connection strings and endpoint URIs.
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Current state of the application.
        /// </summary>
        private AppState appState;

        /// <summary>
        /// A mapping service capable of mapping types into each other.
        /// </summary>
        private IObjectMappingService mapper;

        /// <summary>
        /// Serialization service capable of serializing and deserializing objects to string format.
        /// </summary>
        private IObjectSerializationService serializationService;

        public DatabaseAssetFetchingService(IWebResourceRequestService resourceRequestService, IConfiguration configuration, AppState appstate, IObjectMappingService objectMapper, IObjectSerializationService serializationService)
        {
            this.resourceRequestService = resourceRequestService;
            this.configuration = configuration;
            this.appState = appstate;
            this.mapper = objectMapper;
            this.serializationService = serializationService;
        }

        /// <summary>
        /// Fetches assets from the database based on a specified filter.
        /// </summary>
        /// <param name="filter">The specified filter by which to decide which assets to return.</param>
        /// <returns>A collection of DTOs containing asset data.</returns>
        public async Task<ICollection<DatabaseAssetDTO>> FetchAssets(DatabaseAssetFilterDTO filter)
        {
            var response = await this.resourceRequestService.SubmitResourceAsync($"{this.configuration["BASEURI"]}dataquery/fetchlist?token={this.appState.AuthenticationToken}", filter);

            // Throw exception or do something but dont return null thats only for testing.
            if (!response.IsSuccess)
                return null;

            var dto = await this.serializationService.DeserializeMessageAsync<CompositeDatabaseAssetDTO>(response.Data);

            return dto.DatabaseAssetDTOs;
        }
    }
}
