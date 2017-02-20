using HerhalingNetCore.Api.Api.Models.Products;
using HerhalingNetCore.Api.DataAcces.Context;
using HerhalingNetCore.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HerhalingNetCore.Api.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private EntityContext _context;
        public ProductsController(EntityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _context.Products
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductEdit product)
        {
            if (product == null) return BadRequest("Object mapped incorrectly");

            var productToAdd = new Product
            {
                Name = product.Name,
                PricePerQuantity = product.PricePerQuantity,
                Type = product.Type
            };

            _context.Products.Add(productToAdd);
            _context.SaveChanges();
            return Created("", productToAdd);
        }
    }
}
