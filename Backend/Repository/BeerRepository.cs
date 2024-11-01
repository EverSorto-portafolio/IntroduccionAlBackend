using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _storeContext;

        public BeerRepository(StoreContext storeContext) { 
        _storeContext = storeContext;
        
        }
        public async Task<IEnumerable<Beer>> Get() => await _storeContext.Beers.ToListAsync();

        public async Task<Beer> GetById(int id) => await 
            _storeContext.Beers.FindAsync(id);
        public async Task add(Beer entity) =>   
             await _storeContext.AddAsync(entity);
        
        public  void update(Beer entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }
        public async Task Save() => _storeContext.SaveChanges();
    }
}
