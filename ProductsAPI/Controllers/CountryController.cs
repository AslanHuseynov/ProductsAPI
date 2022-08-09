using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext context;

        public CountryController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDTO>>> Get()
        {
            var countryDTOs = new List<CountryDTO>();
            var countries = await context.Countries.ToListAsync();

            foreach (var country in countries)
            {
                var countryDTO = new CountryDTO()
                {
                    Id = country.Id,
                    CountryName = country.CountryName
                };

                countryDTOs.Add(countryDTO);
            }

            return Ok(countryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> Get(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country == null)
                return BadRequest("Country not found");

            var countryDTO = new CountryDTO()
            {
                Id = country.Id,
                CountryName = country.CountryName
            };
            return Ok(countryDTO);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddProduct(CountryDTO countryDTO)
        {
            var country = new Country
            {
                CountryName = countryDTO.CountryName
            };
            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return Ok($"Country Added Successfully!");
        }

        [HttpPut]
        public async Task<ActionResult<String>> Update(CountryDTO req)
        {
            var country = await context.Countries.FindAsync(req.Id);
            if (country == null)
                return BadRequest("Country not found");

            country.CountryName = req.CountryName;

            await context.SaveChangesAsync();

            return Ok($"Country With Id: {country.Id} has successfully updated!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country == null)
                return BadRequest("Country not found");

            context.Countries.Remove(country);
            await context.SaveChangesAsync();

            return Ok("Succesfully deleted!");
        }
    }
}
