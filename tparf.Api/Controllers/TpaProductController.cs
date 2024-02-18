using Microsoft.AspNetCore.Mvc;
using tparf.Api.Extensions;
using tparf.Api.Interfaces;
using tparf.Api.Repositories;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.TpaProducts;
using tparf.Models.Dtos.TpaProducts.Characteristic;
using tparf.Models.Dtos.TpaProducts.Images;

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
        [Route("addNewProduct")]
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
        [Route("updateProduct/{id:long}")]
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
        [Route("deleteProduct/{id:long}")]
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

        [HttpGet]
        [Route("{prodId:long}/getCharacteristics")]
        public async Task<ActionResult<IEnumerable<CharacteristicDto>>> GetCharacteristicsFromProduct(long prodId)
        {
            try
            {
                var characteristics = await _tpaProductRepository.GetCharacteristicsFromProduct(prodId);
                var characteristicsDto = characteristics.ConvertToDto();
                return Ok(characteristicsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка получения данных из базы данных");
            }
        }

        [HttpPost]
        [Route("characteristics/addNewCharacteristic")]
        public async Task<IActionResult> AddNewCharacteristic([FromBody]CharacteristicDto characteristic)
        {
            try
            {
                var newCharacteristic = await _tpaProductRepository.AddNewCharacteristic(characteristic);
                if(newCharacteristic == null)
                {
                    return NoContent();
                }
                return Ok(newCharacteristic);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }

        [HttpPut]
        [Route("characteristics/updateCharacteristics/{charId:long}")]
        public async Task<IActionResult> UpdateCharacteristic(long charId, UpdateCharacteristicDto updateCharacteristicDto)
        {
            try
            {
                var updateCharacteristic = await _tpaProductRepository.UpdateCharacteristic(charId, updateCharacteristicDto);
                if (updateCharacteristic == null)
                {
                    return NoContent();
                }
                var response = await _tpaProductRepository.GetCharacteristic(charId);
                return Ok(response.ConvertToDto());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("characteristics/deleteCharacteristics/{id:long}")]
        public async Task<ActionResult<Status>> DeleteCharacteristic(long id)
        {
            try
            {
                var characteristic = await _tpaProductRepository.DeleteCharacteristic(id);
                return Ok( characteristic);
            }
            catch(Exception ex)
            {
                return new Status { Message = ex.Message, StatusCode = 500 };
            }
        }

        [HttpGet]
        [Route("{prodId:long}/getImages")]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImagesFromProduct(long prodId)
        {
            try
            {
                var images = await _tpaProductRepository.GetImagesFromProduct(prodId);
                var imagesDto = images.ConvertToDto();
                return Ok(imagesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка получения данных из базы данных");
            }
        }

        [HttpPost]
        [Route("characteristics/addNewImage")]
        public async Task<IActionResult> AddNewImage([FromBody] ImageDto image)
        {
            try
            {
                var newImage = await _tpaProductRepository.AddNewImage(image);
                if (newImage == null)
                {
                    return NoContent();
                }
                return Ok(newImage);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }

        [HttpPut]
        [Route("images/updateImages/{charId:long}")]
        public async Task<IActionResult> UpdateImage(long imgId, UpdateImageDto updateImageDto)
        {
            try
            {
                var updateImage = await _tpaProductRepository.UpdateImage(imgId, updateImageDto);
                if (updateImage == null)
                {
                    return NoContent();
                }
                var response = await _tpaProductRepository.GetImage(imgId);
                return Ok(response.ConvertToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("images/deleteImage/{id:long}")]
        public async Task<ActionResult<Status>> DeleteImage(long id)
        {
            try
            {
                var image = await _tpaProductRepository.DeleteImage(id);
                return Ok(image);
            }
            catch (Exception ex)
            {
                return new Status { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
