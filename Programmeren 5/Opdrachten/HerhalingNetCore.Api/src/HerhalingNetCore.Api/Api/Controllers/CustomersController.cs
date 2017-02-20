using HerhalingNetCore.Api.Api.Models.Customer;
using HerhalingNetCore.Api.DataAcces.Context;
using HerhalingNetCore.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private EntityContext _context;
        public CustomersController(EntityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.Customers
                .Include(x=>x.BillingAddress)
                .Include(x=>x.DeliveryAddres)
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.Customers.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        //TODO: refactor address
        [HttpPost]
        public IActionResult Add([FromBody] CustomerEdit customer)
        {
            if (customer == null) return BadRequest("Object mapped incorrectly");
            if (customer.BillingAddress == 0 || customer.DeliveryAddres == 0) return NotFound("Address not found!");

            var customerToAdd = new Customer
            {
                BillingAddress = _context.Addresses.FirstOrDefault(x=>x.Id == customer.BillingAddress),
                DeliveryAddres = _context.Addresses.FirstOrDefault(x => x.Id == customer.DeliveryAddres),
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            };

            _context.Customers.Add(customerToAdd);
            _context.SaveChanges();
            return Created("", customerToAdd);
        }
    }
}
