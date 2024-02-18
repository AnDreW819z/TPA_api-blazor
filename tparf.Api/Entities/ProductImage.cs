using System.ComponentModel.DataAnnotations.Schema;

namespace tparf.Api.Entities
{
    public class ProductImage
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TpaProduct Product { get; set; }
    }
}
