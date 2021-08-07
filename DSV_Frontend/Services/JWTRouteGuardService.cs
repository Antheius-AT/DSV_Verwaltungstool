//-----------------------------------------------------------------------
// <copyright file="JWTRouteGuardService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.Services
{
    using System.Threading.Tasks;
    using DSV_Frontend.Shared;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Represents a service capable of guarding routes to ensure only authorized users are allowed to access them.
    /// </summary>
    public class JWTRouteGuardService : IRouteGuardService
    {
        private IWebResourceRequestService webRequestService;

        private IConfiguration configuration;

        private AppState appState;

        public JWTRouteGuardService(IWebResourceRequestService webRequestService, IConfiguration configuration, AppState appState)
        {
            this.webRequestService = webRequestService;
            this.configuration = configuration;
            this.appState = appState;
        }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        public string UserToken { get; set; }

        /// <summary>
        /// Verifies the validity of the security token.
        /// </summary>
        /// <returns>A value indicating whether the security token found in <see cref="UserToken"/> is valid.</returns>
        public async Task<bool> VerifySecurityToken()
        {
            var webResponse = await this.webRequestService.GetResourceAsync(string.Concat(this.configuration["BASEURI"], "api/", "authentication/", "verifytoken?", "token=", $"{this.appState.AuthenticationToken}"));

            return webResponse.IsSuccess;
        }
    }
}
