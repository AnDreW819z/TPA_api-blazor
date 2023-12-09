using Microsoft.EntityFrameworkCore;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Api.Interfaces;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.Subcategories;

namespace tparf.Api.Repositories
{
    public class SubcategoruRepository : ISubcategoryRepository
    {
        private readonly TparfDbContext _tparfDbContext;
        private ICategoryRepository _categoryRepository;
        public SubcategoruRepository(TparfDbContext tparfDbContext, ICategoryRepository categoryRepository)
        {
            _tparfDbContext = tparfDbContext;
            _categoryRepository = categoryRepository;
        }

        private async Task<bool> SubcategoryExist(long subId)
        {
            return await _tparfDbContext.Subcategories.AnyAsync(c => c.Id == subId);
        }

        public async Task<Subcategory> AddNewSubcategory(CreateSubcategoryDto createSubDto)
        {
            if (await SubcategoryExist(createSubDto.Id) == false)
            {
                Category category = await _categoryRepository.GetCategory(createSubDto.CategoryId);
                Subcategory subcategory = new Subcategory
                {
                    Name = createSubDto.Name,
                    IconCSS = createSubDto.IconCSS,
                    CategoryId = createSubDto.CategoryId
                    
                };
                if (subcategory != null)
                {
                    var result = await _tparfDbContext.Subcategories.AddAsync(subcategory);
                    await _tparfDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<Status> DeleteSubcategory(long id)
        {
            var subcategory = await _tparfDbContext.Subcategories.FindAsync(id);
            if (subcategory != null)
            {
                _tparfDbContext.Subcategories.Remove(subcategory);
                await _tparfDbContext.SaveChangesAsync();
                return new Status { Message = "Категория успешно удаленa", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }

        public async Task<IEnumerable<TpaProduct>> GetProductFromSubcategory(long id)
        {
            var products = await _tparfDbContext.TpaProducts.Include(p => p.Subcategory).Where(p => p.SubcategoryId == id).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategories()
        {
            var subcategories = await _tparfDbContext.Subcategories.Include(s=>s.Category).ToListAsync();
            return subcategories;
        }

        public async Task<Subcategory> GetSubcategory(long id)
        {
            if (await SubcategoryExist(id))
            {
                var subcategory = await _tparfDbContext.Subcategories.FindAsync(id);
                subcategory.Category = await _categoryRepository.GetCategory(subcategory.CategoryId);
                return subcategory;
            }
            return null;
        }

        public async Task<Subcategory> UpdateSubcategory(long id, UpdateSubcategoryDto updateCatDto)
        {
            var category = await _categoryRepository.GetCategory(updateCatDto.CategoryId);
            var subcategory = await _tparfDbContext.Subcategories.FindAsync(id);
            if (subcategory != null)
            {
                subcategory.Name = updateCatDto.Name;
                subcategory.IconCSS = updateCatDto.IconCSS;
                subcategory.CategoryId = category.Id;
                await _tparfDbContext.SaveChangesAsync();
                return subcategory;
            }
            return null;
        }
    }
}
