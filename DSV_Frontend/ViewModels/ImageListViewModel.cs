//-----------------------------------------------------------------------
// <copyright file="ImageListViewModel.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.ViewModels
{
    using System.Collections.Generic;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents the view model for the <see cref="FPBookList"/> control.
    /// </summary>
    public class ImageListViewModel
    {
        /// <summary>
        /// Gets or sets the collection of images.
        /// </summary>
        public ICollection<ImageDataDTO> Images { get; set; }
    }
}
