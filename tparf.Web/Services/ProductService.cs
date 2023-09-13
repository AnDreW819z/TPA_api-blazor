using System.Net.Http;
using System.Net.Http.Json;
using tparf.Models.Dtos;
using tparf.Web.Services.Contracts;

namespace tparf.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> GetItem(int id)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"api/Product/{id}");
                if (responce.IsSuccessStatusCode)
                {
                    if(responce.StatusCode == System.Net.HttpStatusCode.NoContent) 
                    {
                        return default(ProductDto);
                    }
                    return await responce.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch(Exception ex)
            {
                //Log exception
                throw;
            } 
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var responce = await _httpClient.GetAsync("api/Product");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<ProductDto>();
                    return await responce.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/{categoryId}/GetItemsByCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetProductCategories()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Product/GetProductCategories");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductCategoryDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductCategoryDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
