﻿//-----------------------------------------------------------------------
// <copyright file="UserDataDTO.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    /// <summary>
    /// Represents a dto containing user data.
    /// </summary>
    public class UserDataDTO
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
        /// Gets or sets the user's password hash.
        /// </summary>
        public string Password
        {
            get;
            set;
        }
    }
}
