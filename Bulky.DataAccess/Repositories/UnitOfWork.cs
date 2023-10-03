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
        public ICategoryRepository CategoryRepository { get; private set; }

        /// <summary>
        /// ProductRepository
        /// </summary>
        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            CategoryRepository = new CategoryRepository(_applicationDbContext);
            ProductRepository = new ProductRepository(_applicationDbContext);
        }
    }
}