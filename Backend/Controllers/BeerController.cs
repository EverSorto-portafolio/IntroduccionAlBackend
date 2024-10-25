using Backend.DTOs;
using Backend.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _storeContext;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;

        public BeerController(
            StoreContext storeContext, 
            IValidator<BeerInsertDto> beerInsertValidators,
            IValidator<BeerUpdateDto> beerUpdateValidator)
        {
            _storeContext = storeContext;
            _beerInsertValidator = beerInsertValidators;
            _beerUpdateValidator = beerUpdateValidator;
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


        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto) {

            var  validationREsult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationREsult.IsValid) {
                return BadRequest(validationREsult.Errors);
            }
            
            var beer = new Beer()
            {
                BeerName = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandID,
                Al = beerInsertDto.Al
            };
            await _storeContext.Beers.AddAsync(beer);
            await _storeContext.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beerInsertDto.Name,
                BrandID = beerInsertDto.BrandID,
                Al = beerInsertDto.Al
            };
            return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, beerDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> update(
            int id, BeerUpdateDto beerUpdateDto) 
        {

            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);

            if (!validationResult.IsValid) {

                return BadRequest(validationResult.Errors);
            }




            var beer = await _storeContext.Beers.FindAsync(id);
            if (beer == null) {
                return NotFound();
            }

            beer.BeerName = beerUpdateDto.Name;
            beer.Al = beerUpdateDto.Al;
            beer.BrandId = beerUpdateDto.BrandID;

            await _storeContext.SaveChangesAsync();
            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.BeerName,
                BrandID = beer.BrandId,
                Al = beer.Al
            };
            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var beer = await _storeContext.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            _storeContext.Beers.Remove(beer);
            await _storeContext.SaveChangesAsync();

            return Ok();
        }

    }
}
