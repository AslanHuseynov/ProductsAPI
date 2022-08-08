using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainProductController : ControllerBase
    {
        private readonly DataContext context;

        public MainProductController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MainProduct>>> Get()
        {
            return Ok(await context.MainProducts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MainProduct>> Get(int id)
        {
            var products = await context.MainProducts.FindAsync(id);
            if (products == null)
                return BadRequest("Main Product not found");
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<MainProduct>>> AddMainProduct(MainProduct prd)
        {
            context.MainProducts.Add(prd);
            await context.SaveChangesAsync();

            return Ok(await context.MainProducts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<MainProduct>>> Update(MainProduct req)
        {
            var products = await context.MainProducts.FindAsync(req.Id);
            if (products == null)
                return BadRequest("Main Product not found");

            products.ProductName = req.ProductName;

            await context.SaveChangesAsync();

            return Ok(await context.MainProducts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MainProduct>>> Delete(int id)
        {
            var products = await context.MainProducts.FindAsync(id);
            if (products == null)
                return BadRequest("Main Product not found");

            context.MainProducts.Remove(products);
            await context.SaveChangesAsync();

            return Ok(await context.MainProducts.ToListAsync());
        }
    }
}
