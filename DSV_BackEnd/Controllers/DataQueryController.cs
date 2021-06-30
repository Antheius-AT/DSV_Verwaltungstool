//-----------------------------------------------------------------------
// <copyright file="DataQueryController.cs" company="FSolutions">
//     Copyright (c) FSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_BackEnd.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DSV_BackEnd_DataLayer.DataModel;
    using DSV_BackEnd_ServicesContracts;
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

        public DataQueryController(IDatabaseService databaseService, IObjectSerializationService objectSerializationService)
        {
            this.databaseService = databaseService;
            this.objectSerializationService = objectSerializationService;
        }

        /// <summary>
        /// Asynchronously fetches all available books stored in the database.
        /// </summary>
        /// <returns>A task object handling the logic of fetching the books
        /// and converting them into a string encoded response which is stored in the task's result
        /// on termination.</returns>
        [HttpGet]
        [Route("fetchall/books")]
        public async Task<IActionResult> FetchBooksAsync()
        {
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
        /// <returns>A task object handling the logic of fetching the books and converting them
        /// into a string encoded response which is stored in the task's result on termination.</returns>
        [HttpGet]
        [Route("fetchall/articles")]
        public async Task<IActionResult> FetchArticlesAsync()
        {
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
        /// Persists a book in the underlying database.
        /// </summary>
        /// <param name="book">The book to persist.</param>
        /// <returns>An action result indicating whether the operation was a success.</returns>
        [HttpPost]
        [Route("persist/book")]
        public async Task<IActionResult> PersistBookAsync([FromBody]Book book)
        {
            if (book == null)
                return BadRequest("Book to persist was null.");

            var operationSuccess = await this.databaseService.PersistBookAsync(book);

            return operationSuccess ? Ok() : StatusCode(500);
        }

        /// <summary>
        /// Persists an article in the underlying database.
        /// </summary>
        /// <param name="article">The article to persist.</param>
        /// <returns>An action result indicating whether the operation was a success.</returns>
        [HttpPost]
        [Route("persist/article")]
        public async Task<IActionResult> PersistArticleAsync([FromBody]Article article)
        {
            if (article == null)
                return BadRequest("Article to persist was null.");

            var operationSuccess = await this.databaseService.PersistArticleAsync(article);

            return operationSuccess ? Ok() : StatusCode(500);
        }

        /// <summary>
        /// Uploads an image asynchronously and stores it in the database.
        /// </summary>
        /// <param name="image">The image to upload.</param>
        /// <returns>A task handling the logic of saving the image.</returns>
        [HttpPost]
        [Route("upload/image")]
        public async Task<IActionResult> UploadImageAsync([FromBody]Image image)
        {
            if (image == null)
                return BadRequest("Image to upload was null.");

            var operationSuccess = await this.databaseService.PersistImageAsync(image);

            return operationSuccess ? Ok() : StatusCode(500);
        }

        /// <summary>
        /// Fetches all available images asynchronously.
        /// </summary>
        /// <returns>A task object handling the logic of fetching images.</returns>
        [HttpGet]
        [Route("fetchall/images")]
        public async Task<IActionResult> FetchImagesAsync()
        {
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
        /// Fetches a single image based on its primary key, being the image name.
        /// </summary>
        /// <param name="imageName">The image name.</param>
        /// <returns>A task object handling the logic of fetching the image.</returns>
        [HttpGet]
        [Route("fetchsingle")]
        public async Task<IActionResult> FetchSingleImageAsync(string imageName)
        {
            if (imageName == null)
                return BadRequest("Name of image to fetch was null.");

            try
            {
                var result = await this.databaseService.FetchImageByName(imageName);
                var serializedObject = await this.objectSerializationService.SerializeMessageAsync(result);

                return Content(serializedObject);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}