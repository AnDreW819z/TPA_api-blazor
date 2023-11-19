using Microsoft.AspNetCore.Mvc;
using tparf.Api.Entities;
using tparf.Api.Extensions;
using tparf.Api.Repositories;
using tparf.Api.Repositories.Contracts;
using tparf.Models.Dtos;

namespace tparf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetCategories();
                var productManufacturers = await _productRepository.GetManufacturers();
                if( products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto();
                    return Ok(productDtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItem(long id)
        {
            try
            {
                var product = await this._productRepository.GetItem(id);
                var productCategories = await _productRepository.GetCategories();
                var productManufacturers = await _productRepository.GetManufacturers();
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {

                    var productDto = product.ConvertToDto();

                    return Ok(productDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }
        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await _productRepository.GetCategories();

                var productCategoryDtos = productCategories.ConvertToDto();

                return Ok(productCategoryDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetItemsByCategory(categoryId);
                var productManufacturers = await _productRepository.GetManufacturers();
                var productDtos = products.ConvertToDto();

                return Ok(productDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] CreateProductDto productDto)
        {
            try
            {
                
                var newProduct = await _productRepository.AddNewProduct(productDto);

                if (newProduct == null)
                {
                    return NoContent();
                }
                return Ok(productDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(long id, UpdateProductDto productDto)
        {
            try 
            { 
                var product = await _productRepository.UpdateProduct(id, productDto);
                if (product == null)
                {
                    return NotFound();
                }

                var responce = await _productRepository.GetItem(product.Id);
                var result = responce.ConvertToDto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                var product = await _productRepository.DeleteProduct(id);
                
                return Ok("Товар успешно удален");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
