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
    }
}