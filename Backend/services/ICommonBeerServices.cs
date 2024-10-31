using Backend.DTOs;

namespace Backend.services
{
    public interface ICommonBeerServices<T, IT, UT>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(IT beerInsertDto);
        Task<T> Update(int id, UT beerUpdate);
        Task<T> Delete(int id);
    }
}
