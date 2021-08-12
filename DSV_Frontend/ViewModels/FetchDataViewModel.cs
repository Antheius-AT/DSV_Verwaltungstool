//-----------------------------------------------------------------------
// <copyright file="FetchDataViewModel.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.ViewModels
{
    using System.Collections.Generic;
    using SharedDefinitions.DTOs;

    public class FetchDataViewModel
    {
        /// <summary>
        /// Gets or sets an enumerable of database asset dtos.
        /// </summary>
        public IEnumerable<DatabaseAssetDTO> Data { get; set; }
    }
}
