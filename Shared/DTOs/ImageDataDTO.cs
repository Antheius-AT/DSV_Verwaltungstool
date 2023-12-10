//-----------------------------------------------------------------------
// <copyright file="ImageDataDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    public class ImageDataDTO
    {
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
