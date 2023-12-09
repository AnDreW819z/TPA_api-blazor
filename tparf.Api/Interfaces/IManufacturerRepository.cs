using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Manufacturers;

namespace tparf.Api.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetManufacturers();
        Task<Manufacturer> GetManufacturer(long id);
        Task<IEnumerable<Category>> GetCategoryFromManufacturer(long id);
        //Task<IEnumerable<Subcategory>> GetSubcategoryFromManufacturer(long id);
        //Task<IEnumerable<TpaProduct>> GetProductFromManufacturer(long id);

        public Task<Manufacturer> AddNewManufacturer(ManufacturerDto manufacturerDto);
        public Task<Manufacturer> UpdateManufacturer(long id, UpdateManufacturerDto manufacturerDto);
        public Task<Status> DeleteManufacturer(long id);
    }
}
