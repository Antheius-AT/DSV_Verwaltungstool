//-----------------------------------------------------------------------
// <copyright file="DataQueryController.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd.Controllers
{
    using System;
    using System.Buffers.Text;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_ServicesContracts;
    using DSV_BackEnd_ServicesContracts.ServiceExceptions;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller serving as an endpoint for requesting and submitting data from and to the database.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DataQueryController : ControllerBase
    {
        /// <summary>
        /// Represents an abstract service capable of interacting with the database.
        /// </summary>
        private IDatabaseService databaseService;

        /// <summary>
        /// Represent a service capable of serializing and deserializing objects.
        /// </summary>
        private IObjectSerializationService objectSerializationService;

        /// <summary>
        /// Represents an authentication service.
        /// </summary>
        private IAuthenticationService authService;

        public DataQueryController(IDatabaseService databaseService, IObjectSerializationService objectSerializationService, IAuthenticationService authService)
        {
            this.databaseService = databaseService;
            this.objectSerializationService = objectSerializationService;
            this.authService = authService;
        }

        /// <summary>
        /// Asynchronously fetches all available books stored in the database.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task object handling the logic of fetching the books
        /// and converting them into a string encoded response which is stored in the task's result
        /// on termination.</returns>
        [HttpGet]
        [Route("fetchall/books")]
        public async Task<IActionResult> FetchBooksAsync(string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            try
            {
                var result = await this.databaseService.FetchBooksAsync();
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Asynchronously fetches all available articles stored in the database.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task object handling the logic of fetching the books and converting them
        /// into a string encoded response which is stored in the task's result on termination.</returns>
        [HttpGet]
        [Route("fetchall/articles")]
        public async Task<IActionResult> FetchArticlesAsync(string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            try
            {
                var result = await this.databaseService.FetchArticlesAsync();
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        /// <summary>
        /// Fetches all available images asynchronously.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task object handling the logic of fetching images.</returns>
        [HttpGet]
        [Route("fetchall/images")]
        public async Task<IActionResult> FetchImagesAsync(string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            try
            {
                var result = await this.databaseService.FetchImagesAsync();
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Fetches a single book from the database using the book's unique ID.
        /// </summary>
        /// <param name="bookID">The book ID.</param>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task handling the logic of fetching the book.</returns>
        [HttpGet]
        [Route("fetchsingle/book")]
        public async Task<IActionResult> FetchSingleBookAsync(int bookID, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            try
            {
                var result = await this.databaseService.FetchBookByID(bookID);
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (AssetNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Fetches a single article from the database using the article's unique ID.
        /// </summary>
        /// <param name="articleID">The article ID.</param>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task object handling the logic of fetching the article.</returns>
        [HttpGet]
        [Route("fetchsingle/article")]
        public async Task<IActionResult> FetchSingleArticleAsync(int articleID, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            try
            {
                var result = await this.databaseService.FetchArticleByID(articleID);
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (AssetNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Fetches a single image based on its primary key, being the image name.
        /// </summary>
        /// <param name="imageName">The image name.</param>
        /// <param name="token">The authentication token.</param>
        /// <returns>A task object handling the logic of fetching the image.</returns>
        [HttpGet]
        [Route("fetchsingle/image")]
        public async Task<IActionResult> FetchSingleImageAsync(string imageName, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (imageName == null)
                return BadRequest("Name of image to fetch was null.");

            try
            {
                var result = await this.databaseService.FetchImageByName(imageName);
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (AssetNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Persists a book in the underlying database.
        /// </summary>
        /// <param name="book">The book to persist.</param>
        /// <returns>An action result indicating whether the operation was a success.</returns>
        [HttpPost]
        [Route("persist/book")]
        public async Task<IActionResult> PersistBookAsync([FromBody]Book book, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (book == null)
                return BadRequest("Book to persist was null.");

            var operationSuccess = await this.databaseService.PersistBookAsync(book);

            return operationSuccess ? Ok() : StatusCode(400);
        }

        /// <summary>
        /// Persists an article in the underlying database.
        /// </summary>
        /// <param name="article">The article to persist.</param>
        /// <returns>An action result indicating whether the operation was a success.</returns>
        [HttpPost]
        [Route("persist/article")]
        public async Task<IActionResult> PersistArticleAsync([FromBody]Article article, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (article == null)
                return BadRequest("Article to persist was null.");

            var operationSuccess = await this.databaseService.PersistArticleAsync(article);

            return operationSuccess ? Ok() : StatusCode(400);
        }

        /// <summary>
        /// Uploads an image asynchronously and stores it in the database.
        /// </summary>
        /// <param name="image">The image to upload.</param>
        /// <returns>A task handling the logic of saving the image.</returns>
        [HttpPost]
        [Route("upload/image")]
        public async Task<IActionResult> UploadImageAsync([FromBody]Image image, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (image == null)
                return BadRequest("Image to upload was null.");

            var operationSuccess = await this.databaseService.PersistImageAsync(image);

            return operationSuccess ? Ok() : StatusCode(400);
        }

        /// <summary>
        /// Modifies a book and updates its information.
        /// </summary>
        /// <param name="bookID">The ID of the book to be modified.</param>
        /// <param name="updatedBook">The updated book data.</param>
        /// <returns>A task handling the logic of modifying the book.</returns>
        [HttpPut]
        [Route("modify/book")]
        public async Task<IActionResult> ModifyBookAsync(int bookID, [FromBody]Book updatedBook, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (updatedBook == null)
                return BadRequest("Updated book must not be null.");

            var success = await this.databaseService.ModifyBookAsync(bookID, updatedBook);

            return success ? Ok() : StatusCode(400);
        }

        /// <summary>
        /// Modifies an article and updates its information.
        /// </summary>
        /// <param name="articleID">The ID of the article to be modified.</param>
        /// <param name="updatedArticle">The updated article data.</param>
        /// <returns>A task handling the logic of modifying the article.</returns>
        [HttpPut]
        [Route("modify/article")]
        public async Task<IActionResult> ModifyArticleAsync(int articleID, [FromBody]Article updatedArticle, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (updatedArticle == null)
                return BadRequest("Updated book must not be null.");

            var success = await this.databaseService.ModifyArticleAsync(articleID, updatedArticle);

            return success ? Ok() : StatusCode(400);
        }

        /// <summary>
        /// Modifies an image and updates it.
        /// </summary>
        /// <param name="imageName">The name of the image to update.</param>
        /// <param name="base64ImageData">The base64 encoded image data.</param>
        /// <returns>A task object handling the modification of the image data.</returns>
        [HttpPut]
        [Route("modify/image")]
        public async Task<IActionResult> ModifyImageAsync(string imageName, [FromBody]string base64ImageData, string token)
        {
            if (token == null)
                return BadRequest("Authorization token must not be null.");

            var authorized = await this.authService.AuthorizeRequestAsync(token);

            if (!authorized)
                return Unauthorized();

            if (imageName == null)
                return BadRequest("Image name must not be null if you want to modify it.");

            if (base64ImageData == null)
                return BadRequest("Image data must not be null if you want to replace an existing image with it.");

            var success = await this.databaseService.ModifyImageDataAsync(imageName, base64ImageData);

            return success ? Ok() : StatusCode(400);
        }
    }
}