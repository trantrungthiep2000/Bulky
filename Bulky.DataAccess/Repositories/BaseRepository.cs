using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repositories
{
    /// <summary>
    /// Information of base repository
    /// CreatedBy: ThiepTT(26/09/2023)
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> _dbSet;   

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record create sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<int> Add(T entity)
        {
            _dbSet.Add(entity);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Information of T</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            var entity = await _dbSet.Where(filter).FirstOrDefaultAsync();
            return entity!;  
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List information of T</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;    
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record delete sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<int> Remove(T entity)
        {
            _dbSet.Remove(entity);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result;  
        }

        /// <summary>
        /// Remove range
        /// </summary>
        /// <param name="entities">List of T</param>
        /// <returns>Number record delete sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<int> RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>Number record update sucess</returns>
        /// CreatedBy: ThiepTT(26/09/2023)
        public async Task<int> Update(T entity)
        {
            _dbSet.Update(entity);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}