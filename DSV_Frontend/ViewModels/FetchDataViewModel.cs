//-----------------------------------------------------------------------
// <copyright file="FetchDataViewModel.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.ViewModels
{
    using System.Linq;
    using System.Collections.Generic;
    using SharedDefinitions.DTOs;

    public class FetchDataViewModel
    {
        private int pageSize;

        public FetchDataViewModel()
        {
            this.PageSize = 9;
            this.PageIndex = 0;
        }

        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets an enumerable of database asset dtos.
        /// </summary>
        public ICollection<DatabaseAssetDTO> Data { get; set; }

        public int PageSize
        {
            get => this.pageSize;
            set
            {
                if (value < 1)
                    throw new System.ArgumentException(nameof(value), "Page size cant be negative.");

                this.pageSize = value;
            }
        }

        public int GetNumberOfPages()
        {
            if (this.Data.Count != 0 && this.Data.Count % this.PageSize == 0)
                return this.Data.Count / this.PageSize;
            else
                return this.Data.Count / this.PageSize + 1;
        }

        public IEnumerable<DatabaseAssetDTO> GetDisplayedAssets()
        {
            return this.Data.Skip(this.PageSize * this.PageIndex).Take(this.PageSize);
        }
    }
}
