using HerhalingNetCore.Api.Api.Models.Products;
using HerhalingNetCore.Api.DataAcces.Context;
using HerhalingNetCore.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HerhalingNetCore.Api.Api.Models.Invoices;
using System.Collections.Generic;

namespace HerhalingNetCore.Api.Api.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : Controller
    {
        private EntityContext _context;
        public InvoicesController(EntityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.Invoices
                .Include(x => x.InvoiceLines)
                    .ThenInclude(y => y.Product)
                .Include(x => x.Customer)
                .Include(x => x.Company)
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.Invoices
                .Include(x => x.InvoiceLines)
                .Include(x => x.Customer)
                .Include(x => x.Company)
                .FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] InvoiceEdit invoice)
        {
            if (invoice == null) return BadRequest("Object mapped incorrectly");

            var invoiceToAdd = new Invoice
            {
                Company = _context.Companies.FirstOrDefault(x => x.Id == invoice.Company),
                Customer = _context.Customers.FirstOrDefault(x => x.Id == invoice.Customer),
                InvoiceLines = new List<InvoiceLine>(),
                Name = invoice.Name
            };

            foreach (var invoiceLine in invoice.InvoiceLines)
            {
                if (invoiceLine.Id == 0)
                {
                    invoiceToAdd.InvoiceLines.Add(invoiceLine);
                }
            }
            _context.SaveChanges();
            _context.Invoices.Add(invoiceToAdd);
            _context.SaveChanges();
            return Created("", invoiceToAdd);
        }
    }
}
