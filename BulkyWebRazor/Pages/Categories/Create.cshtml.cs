using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    /// <summary>
    /// Information of create model
    /// CreatedBy: ThiepTT(25/09/2023)
    /// </summary>
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Category Category { get; set; } = default!;

        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// On get
        /// </summary>
        /// CreatedBy: ThiepTT(25/09/2023)
        public void OnGet()
        {
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

            if (ModelState.IsValid)
            {
                await _applicationDbContext.Categories.AddAsync(Category);
                await _applicationDbContext.SaveChangesAsync();

                TempData["success"] = "Category created successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}