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
        /// Backing field of the <see cref="IsAuthenticated"/> class.
        /// </summary>
        private bool isAuthenticated;

        /// <summary>
        /// Event notifying subscribers that the application state has changed.
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return this.isAuthenticated;
            }

            set
            {
                this.isAuthenticated = value;
                this.RaiseStateChanged();
            }
        }

        /// <summary>
        /// Raises the <see cref="StateChanged"/> event.
        /// </summary>
        protected virtual void RaiseStateChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
