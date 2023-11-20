using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Products
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public long CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public long ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
    }
}
