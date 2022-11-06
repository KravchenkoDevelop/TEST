using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private readonly EventsDBContext _dbContext;

        public Repository(EventsDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public T Get(Guid id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>();
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                _dbContext.SaveChanges(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
         
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
