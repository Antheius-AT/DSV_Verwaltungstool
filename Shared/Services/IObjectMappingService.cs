//-----------------------------------------------------------------------
// <copyright file="IDTOMappingService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.Services
{
    /// <summary>
    /// Represent a mapping service capable of mapping two objects.
    /// </summary>
    public interface IObjectMappingService
    {
        /// <summary>
        /// Maps an input object of type <typeparamref name="TInput"/> onto an output object of type <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">The type of the input object.</typeparam>
        /// <typeparam name="TOutput">The type of the output object.</typeparam>
        /// <typeparam name="TInputCollectionType">The generic type of the input, if <paramref name="input"/> is a collection of a generic type.</typeparam>
        /// <typeparam name="TOutputCollectionType">The generic type of the output, if <typeparamref name="TOutput"/> contains a property that is a collection of a generic type.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns>An object of type <typeparamref name="TOutput"/>.</returns>
        public TOutput Map<TInput, TOutput, TInputCollectionType, TOutputCollectionType>(TInput input) where TOutput : new();
    }
}
