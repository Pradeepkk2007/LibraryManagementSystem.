using LibraryManagementSystem.API.DTOs.Category;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();

        CategoryDto GetCategoryById(int categoryId);

        string CreateCategory(CreateCategoryDto createCategoryDto);

        string UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto);

        string DeleteCategory(int categoryId);
    }
}