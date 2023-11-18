using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long CartId { get; set; }
        public string ProductName { get; set;}
        public string ProductDescription { get; set;}
        public string ProductImageUrl { get; set;}
        public decimal Price { get; set;}
        public decimal TotalPrice { get; set;}
        public int Qty { get; set;}
    }
}
