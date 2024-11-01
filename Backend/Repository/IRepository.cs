namespace Backend.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task add(TEntity entity);
        void update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
    }
}
