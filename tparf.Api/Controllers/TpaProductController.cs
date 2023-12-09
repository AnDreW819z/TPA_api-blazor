using Microsoft.AspNetCore.Mvc;
using tparf.Api.Extensions;
using tparf.Api.Interfaces;
using tparf.Api.Repositories;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.TpaProducts;

namespace tparf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TpaProductController : ControllerBase
    {
        private readonly ITpaProductRepository _tpaProductRepository;
        public TpaProductController(ITpaProductRepository tpaProductRepository)
        {
            _tpaProductRepository = tpaProductRepository;
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<ActionResult<IEnumerable<TpaProductDto>>> GetCategories()
        {
            try
            {
                var products = await _tpaProductRepository.GetProducts();
                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDto = products.ConvertToDto();
                    return Ok(productsDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet]
        [Route("getProduct/{id:long}")]
        public async Task<ActionResult<TpaProductDto>> GetProduct(long id)
        {
            try
            {
                var product = await _tpaProductRepository.GetProduct(id);
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
                    "Ошибка получения данных из базы данных");

            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] CreateTpaProductDto productDto)
        {
            try
            {

                var newProduct = await _tpaProductRepository.AddNewProduct(productDto);

                if (newProduct == null)
                {
                    return NoContent();
                }
                return Ok(productDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка создания");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(long id, UpdateTpaProductDto productDto)
        {
            try
            {
                var product = await _tpaProductRepository.UpdateProduct(id, productDto);
                if (product == null)
                {
                    return NotFound();
                }

                var responce = await _tpaProductRepository.GetProduct(product.Id);
                var result = responce.ConvertToDto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Status>> DeleteProduct(long id)
        {
            try
            {
                var product = await _tpaProductRepository.DeleteProduct(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
