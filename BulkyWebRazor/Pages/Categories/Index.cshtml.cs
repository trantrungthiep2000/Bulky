using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Pages.Categories
{
    /// <summary>
    /// Information of index model
    /// CreatedBy: ThiepTT(25/09/2023)
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IEnumerable<Category> Categories { get; set; } = default!;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// On get
        /// </summary>
        /// CreatedBy: ThiepTT(25/09/2023)
        public void OnGet()
        {
            Categories = _applicationDbContext.Categories.ToList();
        }
    }
}