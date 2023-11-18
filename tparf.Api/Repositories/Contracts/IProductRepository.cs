using tparf.Api.Entities;

namespace tparf.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(long id);
        Task<ProductCategory> GetCategory(long id);
        Task<IEnumerable<ProductManufacturer>> GetManufacturers();
        Task<ProductManufacturer> GetProductManufacturer(long id);
        Task<IEnumerable<Product>> GetItemsByCategory(long id);
        public Task<IEnumerable<Product>> GetItemsByManufacturer(long id);

        public Task<Product> AddNewProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<Product> DeleteProduct(Product product);
    }
}
