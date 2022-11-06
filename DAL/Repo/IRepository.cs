namespace DAL
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetAll();


        void Dispose();
    }
}
