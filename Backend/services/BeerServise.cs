using Backend.DTOs;

namespace Backend.services
{
    public class BeerServise : IBeerServices
    {
        public Task<IEnumerable<BeerDto>> Get()
        {
            throw new NotImplementedException();
        }
        public Task<BeerDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            throw new NotImplementedException();
        }
        public Task<BeerDto> Update(int id, BeerUpdateDto beerUpdate)
        {
            throw new NotImplementedException();
        }
        public Task<BeerDto> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
