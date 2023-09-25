using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Pages.Categories
{
    /// <summary>
    /// Information of edit model
    /// CreatedBy: ThiepTT(25/09/2023)
    /// </summary>
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Category Category { get; set; } = default!;

        public EditModel(ApplicationDbContext applicationDbContext)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                TempData["error"] = "Display order cannot exactly match the name";
                return Page();
            }

            var categoryById = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == Category.CategoryId);

            if (categoryById == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _applicationDbContext.Categories.Update(Category);
                await _applicationDbContext.SaveChangesAsync();

                TempData["success"] = "Category updated successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}