//-----------------------------------------------------------------------
// <copyright file="ModelToDTOMappingService.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represent a mapping service capable of mapping models to domain transfer objects.
    /// </summary>
    public class ModelToDTOMappingService : IObjectMappingService
    {
        /// <summary>
        /// Maps an input type onto an output type.
        /// </summary>
        /// <typeparam name="TInput">The input type.</typeparam>
        /// <typeparam name="TOutput">The output type.</typeparam>
        /// <typeparam name="TInputCollectionType">The generic type of the collection if the input type is a collection of another type.</typeparam>
        /// <typeparam name="TOutputCollectionType">The generic type of the output, if the output contains a property being a collection of a generic type.</typeparam>
        /// <param name="input">The input to map.</param>
        /// <returns>The mapped object.</returns>
        public TOutput Map<TInput, TOutput, TInputCollectionType, TOutputCollectionType>(TInput input) where TOutput : new()
        {
            if (input.GetType().GetInterfaces().Contains(typeof(IEnumerable)) || input.GetType().IsArray)
                return this.MapCollection<TInput, TOutput, TInputCollectionType, TOutputCollectionType>(input);
            else
                return this.MapSingle<TInput, TOutput>(input);
        }

        private TOutput MapCollection<TInput, TOutput, TInputCollectionType, TOutputCollectionType>(TInput input)
        {
            // TInput ist eine colletion von irgendwas.
            // TOutput ist ein abstrakter Typ, der ein Property mit einer Liste von einem anderen Typen, genannt Delta hat.
            // Der Typ Delta wiederum, hat ähnliche Properties wie der Typ von dem TInput eine Collection ist.

            var outputCollectionProperty = typeof(TOutput).GetProperties().FirstOrDefault(p => p.PropertyType.IsGenericType) ?? throw new ArgumentException(nameof(TOutput), "Output type must have generic collection property");
            var collection = new List<TOutputCollectionType>();

            foreach (var item in input as IEnumerable<TInputCollectionType>)
            {
                var mappedAsset = this.MapSingle<TInputCollectionType, TOutputCollectionType>(item);
                collection.Add(mappedAsset);
            }

            var output = Activator.CreateInstance<TOutput>();
            outputCollectionProperty.SetValue(output, collection);

            return output;
        }

        private TOutput MapSingle<TInput, TOutput>(TInput input)
        {
            var inputPropertyNames = input.GetType().GetProperties();
            var outputPropertyNames = typeof(TOutput).GetProperties();

            var result = Activator.CreateInstance<TOutput>();

            foreach (var propertyName in inputPropertyNames)
            {
                var property = outputPropertyNames.FirstOrDefault(p => p.Name == propertyName.Name);

                if (property == null)
                    continue;

                if (property.PropertyType == propertyName.PropertyType)
                    property.SetValue(result, propertyName.GetValue(input));
            }

            return result;
        }
    }
}
