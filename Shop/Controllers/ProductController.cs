using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Model;

namespace Shop.Controllers
{
    [Route("Products")]
    public class ProductController : Controller
    {
        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> GetProducts([FromServices]DataContext context)
        {

            var products = await context.Product.Include(x => x.Category).AsNoTracking().ToListAsync();

            return products;
        }
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>>ProductId( int id, [FromServices]DataContext context)
        {
            var Product = await context.Product.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(Product);
        }
        [HttpGet]
        [Route("categories/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>>ProductCategory([FromServices]DataContext context, int id)
        {
            var product = context.Product.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();
            return Ok(product);
        }
        [Route("")]
        [HttpPost]
        [Authorize(Roles ="emploe")]
        public async Task<ActionResult>CadProduct([FromBody] Product model, [FromServices]DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);

            }
            try
            {
                context.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel cadastrar o produto" });
            }
        }
        
    }
}