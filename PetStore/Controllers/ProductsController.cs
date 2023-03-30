using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStore.Context;
using PetStore.Entities;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetById(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(product is null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductEntity product)
        {
            var newProduct = new ProductEntity();
            newProduct.Brand = product.Brand;
            newProduct.Title = product.Title;
            newProduct.CreatedAt = DateTime.Now;
            newProduct.UpdatedAt = DateTime.Now;

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok(newProduct);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> Update(long id, ProductEntity produto)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToUpdate is null)
            {
                return NotFound("Product not found");
            }

            productToUpdate.Brand = produto.Brand;
            productToUpdate.Title = produto.Title;
            productToUpdate.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(productToUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }

            _context.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product deleted");
        }
    }
}
