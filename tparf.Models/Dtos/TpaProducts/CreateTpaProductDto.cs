﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.TpaProducts
{
    public class CreateTpaProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public long SubcategoryId { get; set; }

    }
}
