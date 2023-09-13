using System.ComponentModel.DataAnnotations.Schema;

namespace tparf.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategory ProductCategory { get; set; }
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public ProductManufacturer ProductManufacturer { get; set; }
    }
}
