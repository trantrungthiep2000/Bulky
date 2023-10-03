using Bulky.DataAccess.Repositories.IRepositories;
using Bulky.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    /// <summary>
    /// Information of product controller
    /// CreatedBy: ThiepTT(28/09/2023)
    /// </summary>
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return View(products);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepository.Add(product);
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        public async Task<IActionResult> Edit(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return BadRequest();
            }

            var product = await _unitOfWork.ProductRepository.Get(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepository.Update(product);
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        public async Task<IActionResult> Delete(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return BadRequest();
            }

            var product = await _unitOfWork.ProductRepository.Get(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(28/09/2023)
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await _unitOfWork.ProductRepository.Remove(product);
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}