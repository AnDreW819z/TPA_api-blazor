using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.Categories
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public string ManufacturerName { get; set; }
        public long ManufacturerId { get; set; }
    }
}
