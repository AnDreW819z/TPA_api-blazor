using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos
{
    public class CartItemQtyUpdateDto
    {
        public long CartItemId { get; set; }
        public int Qty { get; set;}
    }
}
