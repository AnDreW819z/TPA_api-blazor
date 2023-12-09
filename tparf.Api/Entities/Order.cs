using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;

namespace tparf.Api.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("CartId")]
        public long CartId { get; set; }
        public DateTime CreateTime = DateTime.Now;
    }
}
