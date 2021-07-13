//-----------------------------------------------------------------------
// <copyright file="AuthenticationController.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd.Controllers
{
    using System;
    using System.Security;
    using System.Threading.Tasks;
    using DSV_BackEnd_ServicesContracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SharedDefinitions;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Represents a service capable of handling authentication and authorization.
        /// </summary>
        private IAuthenticationService authService;

        /// <summary>
        /// Represent a serializationi service capable of serializing objects to string format.
        /// </summary>
        private IObjectSerializationService serializationService;

        /// <summary>
        /// Logging service for the <see cref="AuthenticationController"/> class.
        /// </summary>
        private ILogger<AuthenticationController> authControllerLoggerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="authService">Authentication service capable of handling authentication and authorization.</param>
        /// <param name="serializationService">Object serialization service capable of serializing objects to strings.</param>
        /// <param name="authControllerLogger">Logger service for the <see cref="AuthenticationController"/>.</param>
        public AuthenticationController(IAuthenticationService authService, IObjectSerializationService serializationService, ILogger<AuthenticationController> authControllerLogger)
        {
            this.authService = authService;
            this.serializationService = serializationService;
            this.authControllerLoggerService = authControllerLogger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegistrationAsync(UserDataDTO userDataDTO)
        {
            var success = await this.authService.CompleteRegistrationAsync(userDataDTO);

            return success ? Ok() : StatusCode(400);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(UserDataDTO userDataDTO)
        {
            var success = await this.authService.CompleteAuthenticationAsync(userDataDTO);

            if (!success)
                return BadRequest();

            try
            {
                var token = await this.authService.GenerateAuthenticationTokenAsync(userDataDTO.Username);
                var serializedToken = await this.serializationService.SerializeMessageAsync(token);

                return Content(serializedToken);
            }
            catch (Exception)
            {
                this.authControllerLoggerService.LogError($"Server error while trying to serialize token.");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("verifytoken")]
        public async Task<IActionResult> VerifyTokenAsync(string token)
        {
            if (token == null)
                return BadRequest();

            var verified = await this.authService.AuthorizeRequestAsync(token);

            return verified ? Ok() : StatusCode(401);
        }

        [HttpGet]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            if (token == null)
                return BadRequest();

            var newToken = await this.authService.RefreshAuthenticationTokenAsync(token);

            return Content(newToken);
        }
    }
}