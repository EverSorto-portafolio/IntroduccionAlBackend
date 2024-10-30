using Backend.DTOs;
using Backend.Models;
using Backend.services;
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
        private IBeerServices _beerService;
        public BeerController(
            StoreContext storeContext, 
            IValidator<BeerInsertDto> beerInsertValidators,
            IValidator<BeerUpdateDto> beerUpdateValidator, 
            IBeerServices beerServices
            )
        {
            _storeContext = storeContext;
            _beerInsertValidator = beerInsertValidators;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerServices;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
            await _beerService.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id) {
            var beerDto = await _beerService.GetById(id);

            return  beerDto == null ? NotFound():Ok(beerDto);
        }


        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto) {

            var  validationREsult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationREsult.IsValid) {
                return BadRequest(validationREsult.Errors);
            }
      
            var beerDto = await _beerService.Add(beerInsertDto);
            
            return CreatedAtAction(nameof(GetById), new { id = beerDto.Id }, beerDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> update(
            int id, BeerUpdateDto beerUpdateDto) 
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var beerDto = await _beerService.Update(id, beerUpdateDto);
            return beerDto == null ? NotFound() : Ok(beerDto) ;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id) 
        {
            var beer = await _storeContext.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            _storeContext.Beers.Remove(beer);
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

    }
}
