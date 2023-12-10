//-----------------------------------------------------------------------
// <copyright file="LogoutDTO.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    /// <summary>
    /// Represents a dto containing user data.
    /// </summary>
    public class LogoutDTO
    {
        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user's authentication token.
        /// </summary>
        public string AuthenticationToken
        {
            get;
            set;
        }
    }
}
