using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : ControllerBase
    {
        private readonly DataContext context;

        public ProductsDetailsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDetail>>> Get()
        {
            return Ok(await context.ProductDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> Get(int id)
        {
            var products = await context.ProductDetails.FindAsync(id);
            if (products == null)
                return BadRequest("Product not found");
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductDetail>>> AddProduct(ProductDetail prd)
        {
            context.ProductDetails.Add(prd);
            await context.SaveChangesAsync();

            return Ok(await context.ProductDetails.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductDetail>>> Update(ProductDetail req)
        {
            var products = await context.ProductDetails.FindAsync(req.Id);
            if (products == null)
                return BadRequest("Product not found");

            products.Code = req.Code;
            products.Name = req.Name;
            products.Price = req.Price;
            products.Country = req.Country;
            products.FromDate = req.FromDate;
            products.ToDate = req.ToDate;
            products.KindId = req.KindId;
            products.Kind = req.Kind;

            await context.SaveChangesAsync();

            return Ok(await context.ProductDetails.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductDetail>>> Delete(int id)
        {
            var products = await context.ProductDetails.FindAsync(id);
            if (products == null)
                return BadRequest("Product not found");

            context.ProductDetails.Remove(products);
            await context.SaveChangesAsync();

            return Ok(await context.ProductDetails.ToListAsync());
        }
    }
}
