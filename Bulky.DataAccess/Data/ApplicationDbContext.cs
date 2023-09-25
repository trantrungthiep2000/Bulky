using Bulky.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(22/09/2023)
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }
    }
}
