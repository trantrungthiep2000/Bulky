using System.Linq.Expressions;

namespace Bulky.DataAccess.Repositories.IRepositories
{
    /// <summary>
    /// Information of interface base repository
    /// CreatedBy: ThiepTT(26/09/2023)
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List information of T</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>Information of T</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<T> Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record create sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<int> Add(T entity);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record update sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<int> Update(T entity);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record delete sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<int> Remove(T entity);

        /// <summary>
        /// Remove range
        /// </summary>
        /// <param name="entities">List of T</param>
        /// <returns>Number record delete sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public Task<int> RemoveRange(IEnumerable<T> entities);
    }
}