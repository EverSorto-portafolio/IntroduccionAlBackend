using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _storeContext;

        public BeerController(StoreContext storeContext) {
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
            await _storeContext.Beers.Select(b => new BeerDto {
                Id = b.BrandId,
                Al = b.Al,
                BrandID = b.BrandId,
                Name = b.BeerName
            }).ToListAsync();


        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id) {
            var beer = await _storeContext.Beers.FindAsync(id);
            if (beer == null) {
                return NotFound();            
            }

            var beerDto = new BeerDto {
                Id = beer.BeerId,
                Al = beer.Al,
                BrandID = beer.BrandId,
                Name = beer.BeerName
            };

            return Ok(beerDto);

        }
    }
}
