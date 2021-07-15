//-----------------------------------------------------------------------
// <copyright file="JWTWrapperDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    /// <summary>
    /// Represents information stored in a json web token.
    /// </summary>
    public class JWTWrapperDTO
    {
        /// <summary>
        /// Gets or sets the name stored in the token.
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
