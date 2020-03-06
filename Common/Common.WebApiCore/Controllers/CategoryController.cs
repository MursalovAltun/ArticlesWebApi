using System;
using System.Threading.Tasks;
using Common.DTO;
using Common.Services.Infrastructure.Services;
using Common.WebApiCore.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Common.WebApiCore.Controllers
{
    /// <summary>
    /// Categories management
    /// </summary>
    [Route("Category")]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        /// <summary>
        /// This endpoint is using for create or update a category.
        /// To create a category you must provide an empty Id.
        /// To update existing, you must provide the Id of the category. 
        /// </summary>
        /// <param name="dto">DTO that should pass for create or update category</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Category
        ///     {
        ///         "id": "",
        ///         "Name": "News"
        ///     }
        /// </remarks>
        /// <returns>Category DTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CategoryAddDTO dto)
        {
            var result = await this._categoryService.Edit(dto);
            return Ok(result);
        }

        /// <summary>
        /// This endpoint is using for getting all user's categories
        /// </summary>
        /// <returns>Collection of CategoryDTO</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._categoryService.Get();
            return Ok(result);
        }

        /// <summary>
        /// This endpoint is using for getting specific category by Id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>CategoryDTO</returns>
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var isExists = await this._categoryService.Exists(id);
            if (!isExists) throw new BadRequestException("Category does not exist");
            var result = await this._categoryService.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// This endpoint is using for delete specific category by Id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Success: 200</returns>
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isExists = await this._categoryService.Exists(id);
            if(!isExists) throw new BadRequestException("Category does not exist");
            await this._categoryService.Delete(id);
            return Ok();
        }
    }
}