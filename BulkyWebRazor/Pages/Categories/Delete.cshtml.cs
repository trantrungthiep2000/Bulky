using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BulkyWebRazor.Pages.Categories
{
    /// <summary>
    /// Information of delete model
    /// CreatedBy: ThiepTT(25/09/2023)
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public Category Category { get; set; } = default!;

        public DeleteModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// On get
        /// </summary>
        /// <param name="categoryId">Id of category</param>
        /// CreatedBy: ThiepTT(25/09/2023)
        public void OnGet(int? categoryId)
        {
            if (categoryId != null || categoryId != 0)
            {
                Category = _applicationDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId)!;
            }
        }

        /// <summary>
        /// On post
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(25/09/2023)
        public async Task<IActionResult> OnPost()
        {
            var categoryById = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == Category.CategoryId);

            if (categoryById == null)
            {
                return NotFound();
            }

            _applicationDbContext.Categories.Remove(categoryById);
            await _applicationDbContext.SaveChangesAsync();

            TempData["success"] = "Category deleted successfully";

            return RedirectToPage("Index");
        }
    }
}