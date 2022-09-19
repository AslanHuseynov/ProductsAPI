using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;

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
                return BadRequest("\"Product not found\"");
            return Ok(products);
        }

        [HttpGet("get-productDTO/{id}")]
        public async Task<ActionResult<ProductDetailDTO>> GetProductDTO(int id)
        {
            var product = await context.ProductDetails.FindAsync(id);
            if (product == null)
                return BadRequest("\"Product not found\"");
            var productDTO = new ProductDetailDTO
            {
                Code = product.Code,
                Name = product.Name,
                Price = product.Price
            };
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetail>> AddProduct(ProductDetailRequest prd)
        {
            var productDetail = new ProductDetail
            {
                Code = prd.Code,
                Name = prd.Name,
                Price= prd.Price,
                CountryId = prd.CountryId,
                FromDate = prd.FromDate,
                ToDate = prd.ToDate,
                KindId = prd.KindId
            };
            context.ProductDetails.Add(productDetail);
            await context.SaveChangesAsync();

            return Ok(productDetail);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDetail>> Update(ProductDetailRequest req)
        {
            var products = await context.ProductDetails.FindAsync(req.Id);
            if (products == null)
                return BadRequest("\"Product not found\"");

            products.Code = req.Code;
            products.Name = req.Name;
            products.Price = req.Price;
            products.CountryId = req.CountryId;
            products.FromDate = req.FromDate;
            products.ToDate = req.ToDate;
            products.KindId = req.KindId;

            await context.SaveChangesAsync();

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var products = await context.ProductDetails.FindAsync(id);
            if (products == null)
                return BadRequest("\"Product not found\"");

            context.ProductDetails.Remove(products);
            await context.SaveChangesAsync();

            return Ok("\"Succesfully deleted!\"");
        }
    }
}
