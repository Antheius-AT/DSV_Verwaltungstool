//-----------------------------------------------------------------------
// <copyright file="DatabaseAsset.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSV_BackEnd_DataLayer.DataModel
{
    /// <summary>
    /// Represents an abstract database asset.
    /// Contains properties shared across all assets, such as an ID and a title.
    /// </summary>
    public abstract class DatabaseAsset
    {
        /// <summary>
        /// Gets or sets the assets ID.
        /// </summary>
        [Key]
        public int AssetID
        {
            get;
            set;
        }

        public string AdditionalComments
        {
            get;
            set;
        }
    }
}
