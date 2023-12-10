//-----------------------------------------------------------------------
// <copyright file="DatabaseOperationException.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer.DataLayerExceptions
{
    using System;

    /// <summary>
    /// Represents an exception conveying information that some database operation failed.
    /// </summary>
    public class DatabaseOperationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        public DatabaseOperationException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DatabaseOperationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public DatabaseOperationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
