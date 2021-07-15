//-----------------------------------------------------------------------
// <copyright file="JWTAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DSV_Frontend.Data;
    using Microsoft.Extensions.Configuration;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents an authentication service using JWT.
    /// </summary>
    public class JWTAuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Http client for issuing requests.
        /// </summary>
        private IWebResourceRequestService webRequestService;

        /// <summary>
        /// Configuration object storing base URIs and connection strings.
        /// </summary>
        private IConfiguration configuration;

        public JWTAuthenticationService(IWebResourceRequestService webRequestService, IConfiguration configuration)
        {
            this.webRequestService = webRequestService;
            this.configuration = configuration;
        }

        /// <summary>
        /// Authenticates a user asynchronously.
        /// </summary>
        /// <param name="userData">The user data to authenticate with.</param>
        /// <returns>A json web token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if user data is null.
        /// </exception>
        public async Task<WebResourceResponse> AuthenticateAsync(UserDataDTO userData)
        {
            if (userData == null)
                throw new ArgumentNullException(nameof(userData), "User data must not be null.");

            var result = await this.webRequestService.SubmitResourceAsync<UserDataDTO>(string.Concat(this.configuration["BASEURI"], "api/", "authentication/", "authenticate"), userData);

            return result;
        }

        public Task<WebResourceResponse> RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
