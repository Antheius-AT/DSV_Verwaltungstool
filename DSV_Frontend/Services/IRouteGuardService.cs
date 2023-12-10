//-----------------------------------------------------------------------
// <copyright file="IRouteGuardService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a service capable of guarding routes to ensure only authenticated users can access protected endpoints.
    /// </summary>
    public interface IRouteGuardService
    {
        /// <summary>
        /// Gets or sets the user's authentication token, if available.
        /// </summary>
        string UserToken { get; set; }

        /// <summary>
        /// Verifies that the user token currently stored is valid.
        /// </summary>
        /// <returns>A value indicating whether the token is valid.</returns>
        Task<bool> VerifySecurityToken();
    }
}
