using Backend.Models;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        public async Task<IEnumerable<Beer>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Beer> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task add(Beer entity)
        {
            throw new NotImplementedException();
        }
        public  void update(Beer entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }
        public async Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
