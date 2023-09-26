using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepositories;

namespace Bulky.DataAccess.Repositories
{
    /// <summary>
    /// Information of unit of work
    /// CreatedBy: ThiepTT(26/09/2023)
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// CategoryRepository
        /// </summary>
        public ICategoryRepository CategoryRepository { get; private set; } = default!;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            CategoryRepository = new CategoryRepository(_applicationDbContext);
        }
    }
}