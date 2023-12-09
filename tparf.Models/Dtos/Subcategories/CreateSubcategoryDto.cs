using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Subcategories
{
    public class CreateSubcategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public long CategoryId { get; set; }
    }
}
