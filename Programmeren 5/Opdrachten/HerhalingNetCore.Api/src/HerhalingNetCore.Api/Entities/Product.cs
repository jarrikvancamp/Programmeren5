using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Product : EntityBase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal PricePerQuantity { get; set; }
    }
}
