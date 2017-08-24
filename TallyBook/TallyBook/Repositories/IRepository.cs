using System.Linq;

namespace TallyBook.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// unit of work
        /// </summary>
        IUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// Query all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> LookupAll();
        /// <summary>
        /// 新增一個entity
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        /// <summary>
        /// save change
        /// </summary>
        void Commit();
    }
}