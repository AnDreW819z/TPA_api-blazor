using tparf.Api.Entities;
using tparf.Models.Dtos;

namespace tparf.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(long id);
        Task<ProductCategory> GetCategory(long id);
        public Task<ProductManufacturer> GetManufacturer(long id);
        Task<IEnumerable<ProductManufacturer>> GetManufacturers();
        Task<ProductManufacturer> GetProductManufacturer(long id);
        Task<IEnumerable<Product>> GetItemsByCategory(long id);
        public Task<IEnumerable<Product>> GetItemsByManufacturer(long id);

        
        public Task<Product> AddNewProduct(CreateProductDto productDto);
        public Task<Product> UpdateProduct(long id, UpdateProductDto productDto);
        public Task<Product> DeleteProduct(long id);
    }
}
