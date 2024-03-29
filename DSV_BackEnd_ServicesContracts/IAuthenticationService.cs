﻿//-----------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_ServicesContracts
{
    using System;
    using System.Threading.Tasks;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents a service capable of handling authentication and authorization.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Completes the registration of a new user asynchronously.
        /// </summary>
        /// <param name="userData">The user data containing the data of the user to register.</param>
        /// <returns>A task object handling the logic of registration.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="userData"/> is null.
        /// </exception>
        Task<bool> CompleteRegistrationAsync(UserDataDTO userData);

        /// <summary>
        /// Handles an authentication request based on a user's username and password hash combinations.
        /// </summary>
        /// <param name="userData">The dto containing user data to authenticate.</param>
        /// <returns>A task object handling the logic of authenticating the user.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="userData"/> is null.
        /// </exception>
        Task<bool> CompleteAuthenticationAsync(UserDataDTO userData);

        /// <summary>
        /// Generates an authentication token and serializes it into a json object for further use.
        /// </summary>
        /// <param name="username">The username to issue the authentication token for.</param>
        /// <returns>A task object handling the logic of generating authentication tokens.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Is thrown if the specified <paramref name="username"/> is already used as a token key in the underlying <see cref="IAuthenticationTokenStore"/>.
        /// </exception>
        Task<string> GenerateAuthenticationTokenAsync(string username);

        /// <summary>
        /// Refreshes an authentication token asynchronously.
        /// </summary>
        /// <param name="oldToken">The old, but still valid token.</param>
        /// <returns>A task object handling the logic of issuing a new valid token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="oldToken"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if <paramref name="oldToken"/> already expired.
        /// Is also thrown if <paramref name="oldToken"/> does not contain a name claim.
        /// </exception>
        Task<string> RefreshAuthenticationTokenAsync(string oldToken);

        /// <summary>
        /// Authorizes a request based on the authorization service used.
        /// </summary>
        /// <param name="authorizationHeader">The data containing authorization data, such as authentication tokens.</param>
        /// <returns>A task object handling the logic of authorizing the request.</returns>
        Task<bool> AuthorizeRequestAsync(string authorizationHeader);

        /// <summary>
        /// Logs out by removing all references to the specified username and token.
        /// </summary>
        /// <param name="username">The username of the user logging out.</param>
        /// <param name="token">The current authentication token of the user.</param>
        /// <returns>An empty task object.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="token"/> is null.
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Is thrown if the user trying to log out is not logged in currently.
        /// </exception>
        Task LogoutAsync(string username, string token);
    }
}
