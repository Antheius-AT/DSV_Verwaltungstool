﻿//-----------------------------------------------------------------------
// <copyright file="Book.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SharedDefinitions.Services;
    using SharedDefinitions.Exceptions;

    public class JSONSerializationService : IObjectSerializationService
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
        public Task<string> SerializeMessageAsync<TObjectType>(TObjectType @object)
        {
            try
            {
                return Task.FromResult(JsonConvert.SerializeObject(@object));
            }
            catch (Exception)
            {
                throw;
            }
        }

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
        public Task<TObjectType> DeserializeMessageAsync<TObjectType>(string message)
        {
            try
            {
                return Task.FromResult(JsonConvert.DeserializeObject<TObjectType>(message));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
