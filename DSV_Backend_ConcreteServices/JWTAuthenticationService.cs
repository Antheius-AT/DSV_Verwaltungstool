//-----------------------------------------------------------------------
// <copyright file="JWTAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Backend_ServiceLayer
{
    using System;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_ServicesContracts;
    using DSV_BackEnd_ServicesContracts.ServiceExceptions;
    using JWT.Algorithms;
    using JWT.Builder;
    using JWT.Exceptions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Shared;

    /// <summary>
    /// Represent an authentication service using JWT as its method of authentication and authorization.
    /// </summary>
    public class JWTAuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Secret used for issuing and validating json web tokens.
        /// </summary>
        private string secret;

        /// <summary>
        /// Service capable of interacting with the database.
        /// </summary>
        private IDatabaseService databaseService;

        /// <summary>
        /// Logger for the authentication service.
        /// </summary>
        private ILogger<JWTAuthenticationService> authServiceLogger;

        public JWTAuthenticationService(IDatabaseService databaseService, ILogger<JWTAuthenticationService> authServiceLogger, IConfiguration configuration)
        {
            this.databaseService = databaseService;
            this.authServiceLogger = authServiceLogger;
            this.secret = configuration["SECRET"];
        }

        /// <summary>
        /// Authorizes a request asynchronously by validating the json web token sent in the header.
        /// </summary>
        /// <param name="authorizationHeader">Authorization header checked for a valid JWT.</param>
        /// <returns>A task object handling the logic of checking whether a valid JWT is attached to the request.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="authorizationHeader"/> is null.
        /// </exception>
        public Task<bool> AuthorizeRequestAsync(string authorizationHeader)
        {
            if (authorizationHeader == null)
                throw new ArgumentNullException(nameof(authorizationHeader), "Authorization header must not be null.");

            try
            {
                JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(this.secret)
                    .MustVerifySignature()
                    .Decode(authorizationHeader);

                return Task.FromResult(true);
            }
            catch (TokenExpiredException)
            {
                this.authServiceLogger.LogError($"User attempted to authorize a request using an expired token.");

                return Task.FromResult(false);
            }
            catch (Exception)
            {
                this.authServiceLogger.LogError($"Token specified in authorization request was invalid.");

                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Completes an authentication request by using the <see cref="databaseService"/> to check whether
        /// a <see cref="User"/> with the specified authentication credentials exists.
        /// </summary>
        /// <param name="userData">User data of the user to authenticate.</param>
        /// <returns>A task object handling the logic of completing authentication.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="userData"/> is null
        /// </exception>
        public async Task<bool> CompleteAuthenticationAsync(UserDataDTO userData)
        {
            if (userData == null)
                throw new ArgumentNullException(nameof(userData), "User data must not be null.");

            try
            {
                var user = await this.databaseService.RetrieveUserAsync(userData.Username);

                return user.PasswordHash == userData.PasswordHash;
            }
            catch (AssetNotFoundException)
            {
                this.authServiceLogger.LogInformation($"Specified user {userData.Username} was not found when attempting to authenticate.");

                return false;
            }
        }

        /// <summary>
        /// Completes a registration request by using the <see cref="databaseService"/> to persist
        /// the specified user in the database.
        /// </summary>
        /// <param name="userData">The user data of the user to register.</param>
        /// <returns>A task object handling the logic of registrating the user.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="userData"/> is null
        /// </exception>
        public async Task<bool> CompleteRegistrationAsync(UserDataDTO userData)
        {
            if (userData == null)
                throw new ArgumentNullException(nameof(userData), "User data must not be null.");

            var user = new User();
            user.Username = userData.Username;
            user.PasswordHash = userData.PasswordHash;

            var result = await this.databaseService.PersistUserAsync(user);

            return result;
        }

        /// <summary>
        /// Generates a JSON web token asynchronously.
        /// </summary>
        /// <param name="username">The username to generate the token for.</param>
        /// <returns>A task object handling the logic of generating the token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        public Task<string> GenerateAuthenticationTokenAsync(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username to generate a token for must not be null.");

            var token = JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(this.secret)
                .AddClaim("name", username)
                .ExpirationTime(DateTime.UtcNow.AddMinutes(30))
                .Encode();

            return Task.FromResult(token);
        }

        /// <summary>
        /// Refreshes a JSON web token asynchronously.
        /// </summary>
        /// <param name="oldToken">The old, but still valid, JSON web token to replace.</param>
        /// <returns>A task object handling the logic of refreshing an old json web token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="oldToken"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if <paramref name="oldToken"/> already expired.
        /// </exception>
        public Task<string> RefreshAuthenticationTokenAsync(string oldToken)
        {
            throw new NotImplementedException();
        }
    }
}
