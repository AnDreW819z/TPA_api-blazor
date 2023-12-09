using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Categories;
using tparf.Models.Dtos.Subcategories;

namespace tparf.Api.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<Subcategory>> GetSubcategories();
        Task<Subcategory> GetSubcategory(long id);
        //Task<IEnumerable<Subcategory>> GetSubcategoryFromManufacturer(long id);
        Task<IEnumerable<TpaProduct>> GetProductFromSubcategory(long id);

        public Task<Subcategory> AddNewSubcategory(CreateSubcategoryDto createCatDto);
        public Task<Subcategory> UpdateSubcategory(long id, UpdateSubcategoryDto updateCatDto);
        public Task<Status> DeleteSubcategory(long id);
    }
}
