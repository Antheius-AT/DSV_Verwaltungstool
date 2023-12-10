//-----------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Threading.Tasks;
    using DSV_Frontend.Data;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents a service used for authenticating with the back end server.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Attempt to authenticate with the specified user data.
        /// </summary>
        /// <param name="userData">The user data to authenticate with.</param>
        /// <returns>A web resource response containing the issued token if <paramref name="userData"/> was valid.</returns>
        Task<WebResourceResponse> AuthenticateAsync(UserDataDTO userData);

        /// <summary>
        /// Refreshes a json web token that is about to run out.
        /// </summary>
        /// <param name="token">The json web token about to expire.</param>
        /// <returns>A web resource response containing the new token is <paramref name="token"/> was valid.</returns>
        Task<WebResourceResponse> RefreshTokenAsync(string token);

        /// <summary>
        /// Logs the specified user out and removes all references to their user tokens server sided.
        /// </summary>
        /// <param name="username">The name of the user that is logging out.</param>
        /// <returns>A value indicating whether the operation was a success.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        Task<bool> LogoutAsync(string username);
    }
}
