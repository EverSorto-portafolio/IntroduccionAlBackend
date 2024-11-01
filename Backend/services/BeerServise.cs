using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.services
{
    public class BeerServise : ICommonBeerServices<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private StoreContext _storeContext;
        private IRepository<Beer> _beerRepository;
        public BeerServise(StoreContext storeContext, IRepository<Beer> beerRepository) { 
        _storeContext = storeContext;
        _beerRepository = beerRepository;
        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
          var beer  = await _beerRepository.Get();
            return beer.Select(x => new BeerDto() { 
                Id = x.BeerId,
                Name = x.BeerName,
                BrandID = x.BrandId,
                Al = x.Al,
            });
        }
        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer != null) {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
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
             await _beerRepository.add(beer);
             await _beerRepository.Save();
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
            var beer = await _beerRepository.GetById(id);

            if (beer != null) {
                beer.BeerName = beerUpdateDto.Name;
                beer.Al = beerUpdateDto.Al;
                beer.BrandId = beerUpdateDto.BrandID;

                 _beerRepository.update(beer);
               await _beerRepository.Save();
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
        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _storeContext.Beers.FindAsync(id);
            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
                    Name = beer.BeerName,
                    BrandID = beer.BrandId,
                    Al = beer.Al
                };
                _storeContext.Remove(beer);
               await _storeContext.SaveChangesAsync();
               return beerDto;
            }
            return null;
        }
    }
}
