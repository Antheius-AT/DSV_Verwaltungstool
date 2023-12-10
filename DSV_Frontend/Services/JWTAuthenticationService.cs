//-----------------------------------------------------------------------
// <copyright file="JWTAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Threading.Tasks;
    using DSV_Frontend.Data;
    using DSV_Frontend.Enums;
    using DSV_Frontend.Shared;
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

        /// <summary>
        /// Represents the current application state.
        /// </summary>
        private AppState appState;

        public JWTAuthenticationService(IWebResourceRequestService webRequestService, IConfiguration configuration, AppState appState)
        {
            this.webRequestService = webRequestService;
            this.configuration = configuration;
            this.appState = appState;
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

            var result = await this.webRequestService.SubmitResourceAsync<UserDataDTO>(string.Concat(this.configuration["BASEURI"], "authentication/", "authenticate"), userData, HttpSubmitMethod.Post);

            return result;
        }

        /// <summary>
        /// Sends a request to the remote endpoint to log out the specified user.
        /// </summary>
        /// <param name="username">The specified user.</param>
        /// <returns>A value indicating whether the log out was successful.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        public async Task<bool> LogoutAsync(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username must not be null.");

            var logoutDTO = new LogoutDTO()
            {
                Username = username,
                AuthenticationToken = this.appState.AuthenticationToken
            };

            var response = await this.webRequestService.SubmitResourceAsync(string.Concat(this.configuration["BASEURI"], "authentication/", "logout"), logoutDTO, HttpSubmitMethod.Post);

            return response.IsSuccess;
        }

        public Task<WebResourceResponse> RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
