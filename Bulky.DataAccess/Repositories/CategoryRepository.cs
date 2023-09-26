using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepositories;
using Bulky.Model.Models;

namespace Bulky.DataAccess.Repositories
{
    /// <summary>
    /// Information of category repository
    /// CreatedBy: ThiepTT(26/09/2023)
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}