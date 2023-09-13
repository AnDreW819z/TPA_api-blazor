﻿using Microsoft.EntityFrameworkCore;
using tparf.Api.Data;
using tparf.Api.Entities;
using tparf.Api.Repositories.Contracts;

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

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await _tparfDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
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

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
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

        public async Task<ProductManufacturer> GetProductManufacturer(int id)
        {
            var manufacturer = await _tparfDbContext.ProductManufacturers.FindAsync(id);
            return manufacturer;
        }

        public async Task<IEnumerable<Product>> GetItemsByManufacturer(int id)
        {
            var products = await _tparfDbContext.Products
                                     .Include(p => p.ProductManufacturer)
                                     .Where(p => p.ManufacturerId == id).ToListAsync();
            return products;
        }
    }
}