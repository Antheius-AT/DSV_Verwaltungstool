//-----------------------------------------------------------------------
// <copyright file="ObjectSerializationException.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.Exceptions
{
    using System;

    /// <summary>
    /// Represents an exception meaning that the serialization or deserialization of an object failed.
    /// </summary>
    public class ObjectSerializationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSerializationException"/> class.
        /// </summary>
        public ObjectSerializationException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSerializationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ObjectSerializationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSerializationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="encodedObject">The string encoded object that could not be deserialized.</param>
        public ObjectSerializationException(string message, string encodedObject) : base(message)
        {
            this.EncodedObject = encodedObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSerializationException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="decodedObject">The object that could not be serialized.</param>
        public ObjectSerializationException(string message, object decodedObject) : base(message)
        {
            this.DecodedObject = decodedObject;
        }

        /// <summary>
        /// Gets the string encoded object that could not be deserialized.
        /// </summary>
        public string EncodedObject
        {
            get;
        }

        /// <summary>
        /// Gets the object that could not be deserialized.
        /// </summary>
        public object DecodedObject
        {
            get;
        }
    }
}
