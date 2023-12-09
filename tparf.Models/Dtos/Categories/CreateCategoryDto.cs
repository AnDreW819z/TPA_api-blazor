using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Categories
{
    public class CreateCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public long ManufacturerId { get; set; }
    }
}
