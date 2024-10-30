using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.services
{
    public class BeerServise : IBeerServices
    {
        private StoreContext _storeContext;

        public BeerServise(StoreContext storeContext) { 
        _storeContext = storeContext;
        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
            return await _storeContext.Beers.Select(b => new BeerDto
            {
                Id = b.BeerId,
                Al = b.Al,
                BrandID = b.BrandId,
                Name = b.BeerName

            }).ToListAsync();
        }
        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _storeContext.Beers.FindAsync(id);

            if (beer != null) {
                var beerDto = new BeerDto
                {
                    Id = beer.BrandId,
                    Al = beer.Al,
                    BrandID = beer.BrandId,
                    Name = beer.BeerName
                };
                return beerDto;
            }

            return null;
        }
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
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
            return beerDto;
        }
        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
          var beer = await _storeContext.Beers.FindAsync(id);
            if (beer != null) {
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

                return beerDto;
            }
            return null;
        }
        public Task<BeerDto> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
