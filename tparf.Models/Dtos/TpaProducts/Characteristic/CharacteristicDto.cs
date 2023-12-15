using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Models.Dtos.TpaProducts.Characteristic
{
    public class CharacteristicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long ProductId { get; set; }

    }
}
