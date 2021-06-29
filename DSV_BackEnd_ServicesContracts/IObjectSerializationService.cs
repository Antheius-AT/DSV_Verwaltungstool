//-----------------------------------------------------------------------
// <copyright file="IObjectSerializationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_ServicesContracts
{
    using System;
    using System.Threading.Tasks;
    using ServiceExceptions;

    /// <summary>
    /// Represents an abstract service capable of serializing objects to and from string format.
    /// </summary>
    public interface IObjectSerializationService
    {
        /// <summary>
        /// Serializes an object of type <typeparamref name="TObjectType"/> into a string.
        /// </summary>
        /// <param name="object">The object to serialize.</param>
        /// <returns>A task object handling the serialization logic and containing the serialized message
        /// in its result on termination.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the object to serialize is null.
        /// </exception>
        /// <exception cref="ObjectSerializationException">
        /// Is thrown if the object can not be serialized into a message.
        /// </exception>
        Task<string> SerializeMessageAsync<TObjectType>(TObjectType @object);

        /// <summary>
        /// Deserializes a string into an object of type <typeparamref name="TObjectType"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>A task containing the deserialized object in its result
        /// on termination.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if message is null.
        /// </exception>
        /// <exception cref="ObjectSerializationException">
        /// Is thrown if the specified message can not be deserialized into an object of type <typeparamref name="TObjectType"/>.
        /// </exception>
        Task<TObjectType> DeserializeMessageAsync<TObjectType>(string message);

    }
}
