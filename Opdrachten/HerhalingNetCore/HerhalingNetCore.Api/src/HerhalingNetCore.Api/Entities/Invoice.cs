using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Invoice : EntityBase
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public Company Company { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
