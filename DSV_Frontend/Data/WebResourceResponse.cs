//-----------------------------------------------------------------------
// <copyright file="WebResourceResponse.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Data
{
    /// <summary>
    /// Represents a container containing the response of a web resource request.
    /// </summary>
    public class WebResourceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebResourceResponse"/> class.
        /// </summary>
        /// <param name="success">Whether the response was a success.</param>
        /// <param name="data">The contained data, if <paramref name="success"/> is true.</param>
        public WebResourceResponse(bool success, string data)
        {
            this.IsSuccess = success;
            this.Data = data;
        }

        /// <summary>
        /// Gets a value indicating whether the response was successful.
        /// </summary>
        public bool IsSuccess
        {
            get;
        }

        /// <summary>
        /// Gets the returned data if <see cref="IsSuccess"/> is true.
        /// Otherwise returns null.
        /// </summary>
        public string Data
        {
            get;
        }
    }
}
