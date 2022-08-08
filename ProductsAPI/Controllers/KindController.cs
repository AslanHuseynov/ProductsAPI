using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindController : ControllerBase
    {
        private readonly DataContext context;

        public KindController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kind>>> Get()
        {
            return Ok(await context.Kinds.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kind>> Get(int id)
        {
            var products = await context.Kinds.FindAsync(id);
            if (products == null)
                return BadRequest("Kind not found");
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<Kind>>> AddKind(Kind prd)
        {
            context.Kinds.Add(prd);
            await context.SaveChangesAsync();

            return Ok(await context.Kinds.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Kind>>> Update(Kind req)
        {
            var products = await context.Kinds.FindAsync(req.Id);
            if (products == null)
                return BadRequest("Kind not found");

            products.Name = req.Name;
            products.MainProductId = req.MainProductId;
            products.MainProduct = req.MainProduct;

            await context.SaveChangesAsync();

            return Ok(await context.Kinds.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Kind>>> Delete(int id)
        {
            var products = await context.Kinds.FindAsync(id);
            if (products == null)
                return BadRequest("Kind not found");

            context.Kinds.Remove(products);
            await context.SaveChangesAsync();

            return Ok(await context.Kinds.ToListAsync());
        }
    }
}
