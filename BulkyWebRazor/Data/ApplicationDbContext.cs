using BulkyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(25/09/2023)
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
