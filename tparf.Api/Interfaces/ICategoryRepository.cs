using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Categories;
using tparf.Models.Dtos.Manufacturers;

namespace tparf.Api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(long id);
        Task<IEnumerable<Subcategory>> GetSubcategoryFromCategory(long catid);
        //Task<IEnumerable<Subcategory>> GetSubcategoryFromManufacturer(long id);
        //Task<IEnumerable<TpaProduct>> GetProductFromCategory(long id);

        public Task<Category> AddNewCategory(CreateCategoryDto createCatDto);
        public Task<Category> UpdateCategory(long id, UpdateCategoryDto updateCatDto);
        public Task<Status> DeleteCategory(long id);
    }
}
