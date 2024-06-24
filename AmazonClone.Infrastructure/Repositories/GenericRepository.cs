using AmazonClone.Infrastructure.Data;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AmazonClone.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            var entity = query.FirstOrDefault(filter);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
