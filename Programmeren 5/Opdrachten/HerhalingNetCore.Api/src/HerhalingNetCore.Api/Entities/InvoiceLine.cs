using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class InvoiceLine : EntityBase
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
