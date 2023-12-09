using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.TpaProducts;

namespace tparf.Api.Interfaces
{
    public interface ITpaProductRepository
    {
        Task<IEnumerable<TpaProduct>> GetProducts();
        Task<TpaProduct> GetProduct(long id);
        public Task<TpaProduct> AddNewProduct(CreateTpaProductDto productDto);
        public Task<TpaProduct> UpdateProduct(long id, UpdateTpaProductDto productDto);
        public Task<Status> DeleteProduct(long id);
    }
}
