using HerhalingNetCore.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Api.Models.Invoices
{
    public class InvoiceEdit
    {
        public string Name { get; set; }
        public int Customer { get; set; }
        public int Company { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
