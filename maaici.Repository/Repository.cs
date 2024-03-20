using blog.entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace maaici.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(WebDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public DbSet<T> GetDbSet()
        {
            return _dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> list)
        {
            _dbSet.AddRange(list);
        }

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await _dbSet.AddRangeAsync(list);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }

            return _dbSet.AsQueryable();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> list)
        {
            _dbSet.UpdateRange(list);
        }
    }
}
