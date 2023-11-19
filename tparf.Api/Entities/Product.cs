﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tparf.Api.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
        public long ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual ProductManufacturer ProductManufacturer { get; set; }
    }
}
