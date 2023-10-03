namespace Bulky.DataAccess.Repositories.IRepositories
{
    /// <summary>
    /// Information of interface unit of work
    /// CreatedBy: ThiepTT(26/09/2023)
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// CategoryRepository
        /// </summary>
        public ICategoryRepository CategoryRepository { get; }

        /// <summary>
        /// ProductRepository
        /// </summary>
        public IProductRepository ProductRepository { get; }
    }
}