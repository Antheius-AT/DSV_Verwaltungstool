//-----------------------------------------------------------------------
// <copyright file="BookListViewModel.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.ViewModels
{
    using System.Collections.Generic;
    using DSV_Frontend.UI_Controls.Display;
    using SharedDefinitions.DTOs;

    /// <summary>
    /// Represents the view model for the <see cref="FPBookList"/> control.
    /// </summary>
    public class BookListViewModel
    {
        /// <summary>
        /// Gets or sets the collection of books.
        /// </summary>
        public ICollection<BookDataDTO> Books { get; set; }
    }
}
