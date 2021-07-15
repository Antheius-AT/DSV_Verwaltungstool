//-----------------------------------------------------------------------
// <copyright file="JWTAuthenticationService.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Backend_ServiceLayer
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_ServicesContracts;
    using DSV_BackEnd_ServicesContracts.ServiceExceptions;
    using JWT;
    using JWT.Algorithms;
    using JWT.Builder;
    using JWT.Exceptions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using SharedDefinitions;
    using SharedDefinitions.DTOs;
    using SharedDefinitions.Services;

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

        /// <summary>
        /// Serialization service capable of serializing and deserializing objects into string format.
        /// </summary>
        private IObjectSerializationService serializationService;

        /// <summary>
        /// Represents a token store service capable of storing tokens.
        /// </summary>
        private IAuthenticationTokenStore tokenStore;

        public JWTAuthenticationService
            (IDatabaseService databaseService, 
            ILogger<JWTAuthenticationService> authServiceLogger, 
            IConfiguration configuration, 
            IObjectSerializationService serializationService,
            IAuthenticationTokenStore tokenStore)
        {
            this.databaseService = databaseService;
            this.authServiceLogger = authServiceLogger;
            this.secret = configuration["SECRET"];
            this.serializationService = serializationService;
            this.tokenStore = tokenStore;
        }

        /// <summary>
        /// Authorizes a request asynchronously by validating the json web token sent in the header.
        /// </summary>
        /// <param name="authorizationHeader">Authorization header checked for a valid JWT.</param>
        /// <returns>A task object handling the logic of checking whether a valid JWT is attached to the request.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="authorizationHeader"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if the token stored in <paramref name="authorizationHeader"/> is not known to the application.
        /// </exception>
        public async Task<bool> AuthorizeRequestAsync(string authorizationHeader)
        {
            if (authorizationHeader == null)
                throw new ArgumentNullException(nameof(authorizationHeader), "Authorization header must not be null.");

            try
            {
                if (!await this.tokenStore.DoesValueExist(authorizationHeader))
                    throw new ArgumentException(nameof(authorizationHeader), "Specified token was unknown.");

                JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(this.secret)
                    .MustVerifySignature()
                    .Decode(authorizationHeader);

                return true;
            }
            catch (TokenExpiredException)
            {
                this.authServiceLogger.LogError($"User attempted to authorize a request using an expired token.");

                return false;
            }
            catch (ArgumentException)
            {
                this.authServiceLogger.LogInformation($"User attempted to authorize request using unknown token.");

                return false;
            }
            catch (Exception)
            {
                this.authServiceLogger.LogError($"Token specified in authorization request was invalid.");

                return false;
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
        /// <exception cref="InvalidOperationException">
        /// Is thrown if the username <paramref name="username"/> is already used as a token key in the <see cref="IAuthenticationTokenStore"/> store.
        /// </exception>
        public async Task<string> GenerateAuthenticationTokenAsync(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username to generate a token for must not be null.");

            var token = JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(this.secret)
                .AddClaim("name", username)
                .ExpirationTime(DateTime.UtcNow.AddMinutes(30))
                .Encode();

            if (await this.tokenStore.ContainsKeyAsync(username))
                throw new InvalidOperationException($"Cant store entry because username {username} is already used as a key.");

            await this.tokenStore.StoreAsync(username, token);

            return token;
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
        /// Is also thrown if <paramref name="oldToken"/> does not contain a name field.
        /// </exception>
        public async Task<string> RefreshAuthenticationTokenAsync(string oldToken)
        {
            if (oldToken == null)
                throw new ArgumentNullException(nameof(oldToken), "Old token must not be null.");

            if (!await this.AuthorizeRequestAsync(oldToken))
                throw new ArgumentException(nameof(oldToken), "Token already expired");

            var decodedToken = JwtBuilder.Create().Decode(oldToken);
            var jwtDto = await this.serializationService.DeserializeMessageAsync<JWTWrapperDTO>(decodedToken);

            if (jwtDto.Name == null)
                throw new ArgumentException("token missing name field.");

            await this.NullifyTokenValidityAsync(decodedToken);
            var newlyIssuedToken = await this.GenerateAuthenticationTokenAsync(jwtDto.Name);

            return newlyIssuedToken;
        }

        /// <summary>
        /// Nullifies a json web tokens validity.
        /// </summary>
        /// <param name="token">The json web token to nullify.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="token"/> is null.
        /// </exception>
        private async Task NullifyTokenValidityAsync(string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token), "Token must not be null.");

            var tokenDto = await this.serializationService.DeserializeMessageAsync<JWTWrapperDTO>(token);

            if (tokenDto.Name != null)
            {
                var contains = await this.tokenStore.ContainsKeyAsync(tokenDto.Name);

                if (contains)
                    await this.tokenStore.RemoveByKeyAsync(tokenDto.Name);
            }
        }

        /// <summary>
        /// Decodes a json web token.
        /// </summary>
        /// <param name="token">The token to decode.</param>
        /// <returns>The decoded token.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="token"/> is null.
        /// </exception>
        private string DecodeToken(string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token), "Token to decode must not be null.");

            return JwtBuilder.Create().Decode(token);
        }

        /// <summary>
        /// Logs out by removing all references to the specified username and token.
        /// </summary>
        /// <param name="username">The username of the user logging out.</param>
        /// <param name="token">The current authentication token of the user.</param>
        /// <returns>An empty task object.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="token"/> is null.
        /// Is thrown if <paramref name="username"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Is thrown if the user trying to log out is not logged in currently.
        /// </exception>
        public async Task LogoutAsync(string username, string token)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username must not be null.");

            if (token == null)
                throw new ArgumentNullException(nameof(token), "Token must not be null.");

            if (!await AuthorizeRequestAsync(token) || !await tokenStore.ContainsKeyAsync(username))
                throw new InvalidOperationException("Can not log out user because user is not logged in.");

            await this.tokenStore.RemoveByKeyAsync(username);
        }
    }
}
