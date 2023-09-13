using tparf.Api.Entities;

namespace tparf.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<IEnumerable<ProductManufacturer>> GetManufacturers();
        Task<ProductManufacturer> GetProductManufacturer(int id);
        Task<IEnumerable<Product>> GetItemsByCategory(int id);
        public Task<IEnumerable<Product>> GetItemsByManufacturer(int id);
    }
}
