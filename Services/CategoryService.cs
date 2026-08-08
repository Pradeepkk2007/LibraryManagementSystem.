using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Category;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _context.Categories
                           .Select(category => new CategoryDto
                           {
                               CategoryId = category.CategoryId,
                               CategoryName = category.CategoryName,
                               Description = category.Description
                           })
                           .ToList();
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var category = _context.Categories
                                   .FirstOrDefault(x => x.CategoryId == categoryId);

            if (category == null)
            {
                throw new NotFoundException("Category not found.");
            }

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        public string CreateCategory(CreateCategoryDto createCategoryDto)
        {
            bool categoryExists = _context.Categories.Any(x =>
                x.CategoryName == createCategoryDto.CategoryName);

            if (categoryExists)
            {
                throw new BadRequestException("Category already exists.");
            }

            var category = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Description = createCategoryDto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Categories.Add(category);

            _context.SaveChanges();

            return "Category created successfully.";
        }

        public string UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            var category = _context.Categories
                                   .FirstOrDefault(x => x.CategoryId == categoryId);

            if (category == null)
            {
                throw new NotFoundException("Category not found.");
            }

            category.CategoryName = updateCategoryDto.CategoryName;
            category.Description = updateCategoryDto.Description;
            category.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return "Category updated successfully.";
        }

        public string DeleteCategory(int categoryId)
        {
            var category = _context.Categories
                                   .FirstOrDefault(x => x.CategoryId == categoryId);

            if (category == null)
            {
                throw new NotFoundException("Category not found.");
            }

            _context.Categories.Remove(category);

            _context.SaveChanges();

            return "Category deleted successfully.";
        }
    }
}