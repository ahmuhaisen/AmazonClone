using System.Linq.Expressions;


namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
