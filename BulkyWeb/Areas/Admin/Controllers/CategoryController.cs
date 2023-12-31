﻿using Bulky.DataAccess.Repositories.IRepositories;
using Bulky.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    /// <summary>
    /// Information of category controller
    /// CreatedBy: ThiepTT(22/09/2023)
    /// </summary>
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return View(categories);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.CategoryRepository.Add(category);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        public async Task<IActionResult> Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return BadRequest();
            }

            var category = await _unitOfWork.CategoryRepository.Get(c => c.CategoryId == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.CategoryRepository.Update(category);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        public async Task<IActionResult> Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return BadRequest();
            }

            var category = await _unitOfWork.CategoryRepository.Get(c => c.CategoryId == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(22/09/2023)
        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            await _unitOfWork.CategoryRepository.Remove(category);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}