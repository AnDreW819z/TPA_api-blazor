using Microsoft.AspNetCore.Mvc;
using tparf.Api.Extensions;
using tparf.Api.Interfaces;
using tparf.Api.Repositories;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Categories;
using tparf.Models.Dtos.Subcategories;
using tparf.Models.Dtos.TpaProducts;

namespace tparf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoryController(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        [HttpGet]
        [Route("getSubcategories")]
        public async Task<ActionResult<IEnumerable<SubcategoryDto>>> GetCategories()
        {
            try
            {
                var subcategories = await _subcategoryRepository.GetSubcategories();
                if (subcategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var subcategoriesDto = subcategories.ConvertToDto();
                    return Ok(subcategoriesDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet]
        [Route("getSubcategory/{id:long}")]
        public async Task<ActionResult<CategoryDto>> GetSubcategory(long id)
        {
            try
            {
                var subcategory = await _subcategoryRepository.GetSubcategory(id);
                if (subcategory == null)
                {
                    return NotFound();
                }
                else
                {
                    var subcategoryDto = subcategory.ConverToDto();
                    return Ok(subcategoryDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet]
        [Route("getProducts/{subId:long}")]
        public async Task<ActionResult<IEnumerable<TpaProductDto>>> GetProductFromCategory(long subid)
        {
            try
            {
                var products = await _subcategoryRepository.GetProductFromSubcategory(subid);
                var productsDto = products.ConvertToDto();
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubcategory([FromBody] CreateSubcategoryDto subcategoryDto)
        {
            try
            {
                var newSubcategory = await _subcategoryRepository.AddNewSubcategory(subcategoryDto);
                if (newSubcategory == null)
                {
                    return NoContent();
                }
                return Ok(newSubcategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubcategory(long id, UpdateSubcategoryDto subcategoryDto)
        {
            try
            {
                var updateSubategory = await _subcategoryRepository.UpdateSubcategory(id, subcategoryDto);
                if (updateSubategory == null)
                {
                    return NoContent();
                }
                var response = await _subcategoryRepository.GetSubcategory(updateSubategory.Id);
                var result = response.ConverToDto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Status>> DeleteCategory(long id)
        {
            try
            {
                var subcategory = await _subcategoryRepository.DeleteSubcategory(id);
                return subcategory;
            }
            catch (Exception ex)
            {
                return new Status { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
