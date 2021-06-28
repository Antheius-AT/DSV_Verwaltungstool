//-----------------------------------------------------------------------
// <copyright file="DatabaseAsset.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
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
        public int AssetID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the previous storage location of this asset.
        /// </summary>
        public string PreviousStorageLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a string array containing strings representing the byte format
        /// of stored images associated with this asset.
        /// </summary>
        public string[] Base64EncodedImageBytes
        {
            get;
            set;
        }
    }
}
