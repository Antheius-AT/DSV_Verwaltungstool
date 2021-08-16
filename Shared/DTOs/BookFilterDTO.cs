//-----------------------------------------------------------------------
// <copyright file="BookFilterDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    /// <summary>
    /// Represent a filter containing filter properties for books.
    /// </summary>
    public class BookFilterDTO
    {
        /// <summary>
        /// Gets or sets the title to use for filtering.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author used for filtering.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the ISBN used for filtering.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the publisher used for filtering.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the editor used for filtering.
        /// </summary>
        public string Editor { get; set; }
    }
}
