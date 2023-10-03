using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepositories;
using Bulky.Model.Models;

namespace Bulky.DataAccess.Repositories
{
    /// <summary>
    /// Information of product repository
    /// CreatedBy: ThiepTT(28/09/2023)
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}