using System.ComponentModel.DataAnnotations.Schema;

namespace tparf.Api.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public long ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }
        //public IEnumerable<Subcategory> Subcategories { get; set; }
    }
}
