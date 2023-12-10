//-----------------------------------------------------------------------
// <copyright file="Image.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd_DataLayer.DataModel
{
    /// <summary>
    /// Represents an image uploaded by the user.
    /// </summary>
    public class Image : DatabaseAsset
    {
        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public string ImageName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image data, encoded as a base64 string.
        /// </summary>
        public string Base64EncodedImageData
        {
            get;
            set;
        }
    }
}
