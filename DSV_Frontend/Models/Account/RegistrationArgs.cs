//-----------------------------------------------------------------------
// <copyright file="Article.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Tom-Michael Pirich</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Models.Account
{
    using System;

    /// <summary>
    /// Represents the arguments for a newly registered user.
    /// </summary>
    public class RegistrationArgs
    {
        /// <summary>
        /// The name of the newly registered user.
        /// </summary>
        private string username;

        /// <summary>
        /// The password of the newly registered user.
        /// </summary>
        private string password;
        private string eMail;

        /// <summary>
        /// Gets or sets the name of the newly registered user.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The value cannot be null or contain only white spaces.", nameof(this.Username));

                this.username = value;
            }
        }

        /// <summary>
        /// Gets or sets the password of the newly registered user.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The value cannot be null or contain only white spaces.", nameof(this.Password));

                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address of the newly registered user.
        /// </summary>
        public string EMail
        {
            get
            {
                return this.eMail;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The value cannot be null or contain only white spaces.", nameof(this.EMail));

                this.eMail = value;
            }
        }
    }
}