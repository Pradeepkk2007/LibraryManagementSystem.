using LibraryManagementSystem.API.DTOs.Category;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [Authorize]
        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var message = _categoryService.CreateCategory(createCategoryDto);

            return Ok(message);
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            var message = _categoryService.UpdateCategory(categoryId, updateCategoryDto);

            return Ok(message);
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var message = _categoryService.DeleteCategory(categoryId);

            return Ok(message);
        }
    }
}