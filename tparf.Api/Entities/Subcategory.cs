using System.ComponentModel.DataAnnotations.Schema;

namespace tparf.Api.Entities
{
    public class Subcategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        //public IEnumerable<TpaProduct> TpaProducts { get; set; }
    }
}
