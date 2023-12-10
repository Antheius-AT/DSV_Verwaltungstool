//-----------------------------------------------------------------------
// <copyright file="User.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer.DataModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents an object storing information about users using this application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets a user's username.
        /// </summary>
        [Key]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a hashed version of the users password.
        /// </summary>
        public string PasswordHash
        {
            get;
            set;
        }
    }
}
