using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;

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
        public async Task<ActionResult<Kind>> AddKind(KindRequest prd)
        {
            var kind = new Kind
            {
                Id = prd.Id,
                Name = prd.Name,
                ParentId = prd.ParentId
            };
            context.Kinds.Add(kind);
            await context.SaveChangesAsync();

            return Ok(kind);
        }

        [HttpPut]
        public async Task<ActionResult<Kind>> Update(KindRequest req)
        {
            var kind = await context.Kinds.FindAsync(req.Id);
            if (kind == null)
                return BadRequest("Kind not found");

            kind.Name = req.Name;
            kind.ParentId = req.ParentId;

            await context.SaveChangesAsync();

            return Ok(kind);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var kind = await context.Kinds.FindAsync(id);
            if (kind == null)
                return BadRequest("Kind not found");

            context.Kinds.Remove(kind);
            await context.SaveChangesAsync();

            return Ok("\"Succesfully deleted!\"");
        }
    }
}
