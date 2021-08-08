//-----------------------------------------------------------------------
// <copyright file="AppState.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Shared
{
    using System;

    /// <summary>
    /// Represents the current's application state regarding authentication.
    /// </summary>
    public class AppState
    {
        /// <summary>
        /// Event notifying subscribers that the application state has changed.
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the user is currently authenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets the users username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// Raises the <see cref="StateChanged"/> event.
        /// </summary>
        public virtual void RaiseStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
