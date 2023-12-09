using Microsoft.EntityFrameworkCore;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Api.Interfaces;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Categories;

namespace tparf.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TparfDbContext _tparfDbContext;
        public readonly IManufacturerRepository _manufacturerRepository;

        public CategoryRepository(TparfDbContext tparfDbContext, IManufacturerRepository manufacturerRepository)
        {
            _tparfDbContext = tparfDbContext;
            _manufacturerRepository = manufacturerRepository;
        }

        private async Task<bool> CategoryExist(long catId)
        {
            return await _tparfDbContext.Categories.AnyAsync(c => c.Id == catId);
        }

        public async Task<Category> AddNewCategory(CreateCategoryDto createCatDto)
        {
            if(await CategoryExist(createCatDto.Id) == false)
            {
                var manufacturer = await _manufacturerRepository.GetManufacturer(createCatDto.ManufacturerId);
                Category category = new Category
                {
                    Name= createCatDto.Name,
                    IconCSS= createCatDto.IconCSS,
                    ManufacturerId= createCatDto.ManufacturerId
                };
                if (category != null)
                {
                    var result = await _tparfDbContext.Categories.AddAsync(category);
                    await _tparfDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<Status> DeleteCategory(long id)
        {
            var category = await _tparfDbContext.Categories.FindAsync(id);
            if(category!= null)
            {
                _tparfDbContext.Categories.Remove(category); 
                await _tparfDbContext.SaveChangesAsync();
                return new Status { Message = "Категория успешно удаленa", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            
            var categories = await _tparfDbContext.Categories.Include(m=>m.Manufacturer).ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(long id)
        {
            if(await CategoryExist(id))
            {
                var category = await _tparfDbContext.Categories.FindAsync(id);
                category.Manufacturer = await _manufacturerRepository.GetManufacturer(category.ManufacturerId);
                return category;
            }
            return null;
        }

        //public async Task<IEnumerable<TpaProduct>> GetProductFromCategory(long id)
        //{
        //    var products = await _tparfDbContext.TpaProducts.Include(p=>p.Category).Where(p=>p.CategoryId== id).ToListAsync();
        //    return products;
        //}

        public async Task<IEnumerable<Subcategory>> GetSubcategoryFromCategory(long catid)
        {
            var subcategory = await _tparfDbContext.Subcategories.Include(s=>s.Category).Where(s=>s.CategoryId== catid).ToListAsync();
            return subcategory;
        }

        public async Task<Category> UpdateCategory(long id, UpdateCategoryDto updateCatDto)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturer(updateCatDto.ManufacturerId);
            var category = await _tparfDbContext.Categories.FindAsync(id);
            if(category != null)
            {
                category.Name = updateCatDto.Name;
                category.IconCSS = updateCatDto.IconCSS;
                category.ManufacturerId = manufacturer.Id;
                await _tparfDbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
