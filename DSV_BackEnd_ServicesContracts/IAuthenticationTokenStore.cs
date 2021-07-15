//-----------------------------------------------------------------------
// <copyright file="IAuthenticationTokenStore.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_ServicesContracts
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a token storage for authentication tokens.
    /// </summary>
    public interface IAuthenticationTokenStore
    {
        /// <summary>
        /// Stores a token as a new entry.
        /// </summary>
        /// <param name="key">The key associated with the token.</param>
        /// <param name="token">The token to store.</param>
        /// <returns>A task object handling the logic.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is null.
        /// Thrown if <paramref name="token"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if <paramref name="key"/> is already in use.
        /// </exception>
        Task StoreAsync(string key, string token);

        /// <summary>
        /// Retrieves a token based on its key.
        /// </summary>
        /// <param name="key">The key associated with the token.</param>
        /// <returns>The retrieved token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if <paramref name="key"/> was not associated with a token.
        /// </exception>
        Task<string> RetrieveByKeyAsync(string key);

        /// <summary>
        /// Checks whether the specified key is in use.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>Whether the key is in use.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="key"/> is null.
        /// </exception>
        Task<bool> ContainsKeyAsync(string key);

        /// <summary>
        /// Removes an entry using its associated key from the token store.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>A task handling the logic.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is null.
        /// </exception>
        Task RemoveByKeyAsync(string key);

        /// <summary>
        /// Checks whether a specified token exists in the token store.
        /// </summary>
        /// <param name="token">The token to check for existence.</param>
        /// <returns>Whether the token exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="token"/> is null.
        /// </exception>
        Task<bool> DoesValueExist(string token);
    }
}
