using Microsoft.EntityFrameworkCore;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Api.Interfaces;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.TpaProducts;

namespace tparf.Api.Repositories
{
    public class TpaProductRepository : ITpaProductRepository
    {
        private readonly TparfDbContext _tparfDbContext;
        private readonly ISubcategoryRepository _subcategoryRepository;
        public TpaProductRepository(TparfDbContext tparfDbContext, ISubcategoryRepository subcategoryRepository)
        {
            _tparfDbContext = tparfDbContext;
            _subcategoryRepository = subcategoryRepository;
        }

        private async Task<bool> ProductExist(long productId)
        {
            return await _tparfDbContext.TpaProducts.AnyAsync(c => c.Id == productId);
        }

        public async Task<TpaProduct> AddNewProduct(CreateTpaProductDto productDto)
        {
            if (await ProductExist(productDto.Id) == false)
            {
                Subcategory subcategory = await _subcategoryRepository.GetSubcategory(productDto.SubcategoryId);
                TpaProduct product = new TpaProduct
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Article = productDto.Article,
                    ImageUrl = productDto.ImageUrl,
                    Price = productDto.Price,
                    Discount= productDto.Discount,
                    SubcategoryId = productDto.SubcategoryId
                };
                if (product != null)
                {
                    await _tparfDbContext.TpaProducts.AddAsync(product);
                    await _tparfDbContext.SaveChangesAsync();
                    return product;
                }
            }
            return null;
        }

        public async Task<Status> DeleteProduct(long id)
        {
            TpaProduct product = await _tparfDbContext.TpaProducts.FindAsync(id);
            if (product != null)
            {
                _tparfDbContext.TpaProducts.Remove(product);
                await _tparfDbContext.SaveChangesAsync();
                return new Status { Message = "Товар успешно удален", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }


        public async Task<TpaProduct> GetProduct(long id)
        {

            if (await ProductExist(id))
            {
                var product = await _tparfDbContext.TpaProducts.SingleOrDefaultAsync(c => c.Id == id);
                product.Subcategory = await _subcategoryRepository.GetSubcategory(product.SubcategoryId);
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<TpaProduct>> GetProducts()
        {
            var products = await _tparfDbContext.TpaProducts.Include(p=>p.Subcategory).ToListAsync();
            return products;
        }

        public async Task<TpaProduct> UpdateProduct(long id, UpdateTpaProductDto productDto)
        {
            var product = await _tparfDbContext.TpaProducts.FindAsync(id);
            var subcategory = await _subcategoryRepository.GetSubcategory(productDto.SubcategoryId);
            if (product != null)
            {
                product.Name= productDto.Name;
                product.Description= productDto.Description;
                product.Article = productDto.Article;
                product.ImageUrl= productDto.ImageUrl;
                product.Price= productDto.Price;
                product.Discount= productDto.Discount;
                product.SubcategoryId= subcategory.Id;
                await _tparfDbContext.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
