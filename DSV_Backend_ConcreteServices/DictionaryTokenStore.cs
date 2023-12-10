//-----------------------------------------------------------------------
// <copyright file="DictionaryTokenStore.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Backend_ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DSV_BackEnd_ServicesContracts;

    /// <summary>
    /// Represents a dictionary capable of storing tokens.
    /// </summary>
    public class DictionaryTokenStore : IAuthenticationTokenStore
    {
        /// <summary>
        /// Dictionary mapping keys to tokens.
        /// </summary>
        private Dictionary<string, string> keyStore;

        public DictionaryTokenStore()
        {
            this.keyStore = new Dictionary<string, string>();
        }

        /// <summary>
        /// Checks whether the specified key is in use.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>Whether the key is in use.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="key"/> is null.
        /// </exception>
        public Task<bool> ContainsKeyAsync(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "Key must not be null.");

            return Task.FromResult(this.keyStore.ContainsKey(key));
        }

        /// <summary>
        /// Checks whether a specified value exists in the token store.
        /// </summary>
        /// <param name="token">The token to look for.</param>
        /// <returns>Whether the token exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="token"/> is null.
        /// </exception>
        public Task<bool> DoesValueExist(string token)
        {
            return Task.FromResult(this.keyStore.ContainsValue(token));
        }

        /// <summary>
        /// Removes an entry using the specified key.
        /// </summary>
        /// <param name="key">The specified key of the entry to remove.</param>
        /// <returns>Task handling the logic.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="key"/> is null.
        /// </exception>
        public Task RemoveByKeyAsync(string key)
        {
            if (this.keyStore.ContainsKey(key))
                this.keyStore.Remove(key);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Retrieves a token based on its key.
        /// </summary>
        /// <param name="key">The associated key.</param>
        /// <returns>The retrieved token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="key"/> is not associated with any value.
        /// </exception>
        public Task<string> RetrieveByKeyAsync(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "Key must not be null.");

            if (!this.keyStore.ContainsKey(key))
                throw new ArgumentException(nameof(key), "Key not found in store.");

            return Task.FromResult(this.keyStore[key]);
        }

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
        public Task StoreAsync(string key, string token)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "Key must not be null.");

            if (token == null)
                throw new ArgumentNullException(nameof(token), "Token must not be null.");

            if (this.keyStore.ContainsKey(key))
                throw new ArgumentException(nameof(key), "Key is already in use.");

            this.keyStore.Add(key, token);

            return Task.CompletedTask;
        }
    }
}
