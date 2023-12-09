using Microsoft.EntityFrameworkCore;
using tparf.Api.Interfaces;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Models.Dtos.Products;

namespace tparf.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TparfDbContext _tparfDbContext;
        public ProductRepository(TparfDbContext tparfDbContext)
        {
            _tparfDbContext= tparfDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _tparfDbContext.ProductCategories.ToListAsync();

            return categories;

        }

        public async Task<ProductCategory> GetCategory(long id)
        {
            var category = await _tparfDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }
        public async Task<ProductManufacturer> GetManufacturer(long id)
        {
            ProductManufacturer manufacturer = await _tparfDbContext.ProductManufacturers.SingleOrDefaultAsync(c => c.Id == id);
            return manufacturer;
        }

        public async Task<Product> GetItem(long id)
        {
            var product = await _tparfDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _tparfDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(long id)
        {
            var products = await _tparfDbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductManufacturer>> GetManufacturers()
        {
            var manufacturers = await _tparfDbContext.ProductManufacturers.ToListAsync();
            return manufacturers;
        }

        public async Task<ProductManufacturer> GetProductManufacturer(long id)
        {
            var manufacturer = await _tparfDbContext.ProductManufacturers.FindAsync(id);
            return manufacturer;
        }

        public async Task<IEnumerable<Product>> GetItemsByManufacturer(long id)
        {
            var products = await _tparfDbContext.Products
                                     .Include(p => p.ProductManufacturer)
                                     .Where(p => p.ManufacturerId == id).ToListAsync();
            return products;
        }

        private async Task<bool> ProductExist(long productId)
        {
            return await _tparfDbContext.Products.AnyAsync(c => c.Id== productId);
        }

        public async Task<Product> AddNewProduct(CreateProductDto productDto)
        {
            if (await ProductExist(productDto.Id) == false)
            {
                var cat = await GetCategory(productDto.CategoryId);
                var manufact = await GetManufacturer(productDto.ManufacturerId);
                Product product= new Product
                {
                    //Id = productDto.Id,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Article = productDto.Article,
                    ImageUrl = productDto.ImageUrl,
                    Price = productDto.Price,
                    Qty = productDto.Qty,
                    CategoryId= productDto.CategoryId,
                    ManufacturerId= productDto.ManufacturerId,
                };
                if(product != null)
                {
                    var result = await _tparfDbContext.Products.AddAsync(product);
                    await _tparfDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<Product> UpdateProduct(long id, UpdateProductDto productDto)
        {
            var cat = await GetCategory(productDto.CategoryId);
            var manufact = await GetManufacturer(productDto.ManufacturerId);
            var product = await _tparfDbContext.Products.FindAsync(id);
            if(product != null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Article = productDto.Article;
                product.ImageUrl = productDto.ImageUrl;
                product.Price = productDto.Price;
                product.Qty = productDto.Qty;
                product.CategoryId = productDto.CategoryId;
                product.ManufacturerId = productDto.ManufacturerId;
                await _tparfDbContext.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<Product> DeleteProduct(long id)
        {
            Product product = await _tparfDbContext.Products.FindAsync(id);
            if(product != null )
            {
                _tparfDbContext.Products.Remove(product);
                await _tparfDbContext.SaveChangesAsync();
            }
            return product;
        }
    }
}
