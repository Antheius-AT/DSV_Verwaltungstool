//-----------------------------------------------------------------------
// <copyright file="AssetNotFoundException.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_ServicesContracts.ServiceExceptions
{
    using System;

    /// <summary>
    /// Represents an exception conveying information that some database operation failed.
    /// </summary>
    public class AssetNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        public AssetNotFoundException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public AssetNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public AssetNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
