using Microsoft.EntityFrameworkCore;
using RK_A11.DB;
using RK_A11.DTO;
using RK_A11.Interface;
using RK_A11.Utilities;

namespace RK_A11.Services
{
    public class CategoryService : ICategoryService
    {
        private InventoryContext _context;
        public CategoryService(InventoryContext context)
        {
            _context = context;
        }

        public async Task AddCategory(CategoryDTO dto)
        {
            await _context.Categories.AddAsync(dto.CategoryDTOToEntity());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            return await _context.Categories.Select(category => category.CategoryEntityToDTO()).ToListAsync();
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            var foundCategory = await _context.Categories.FindAsync(id);
            if (foundCategory != null)
                return foundCategory.CategoryEntityToDTO();
            return null;
        }

        public async Task UpdateCategory(int id, CategoryDTO dto)
        {
            var categoryToEdit = await _context.Categories.FindAsync(id);
            if (categoryToEdit != null)
            {
                categoryToEdit = dto.CategoryDTOToEntity();
                categoryToEdit.CategoryId = id;
                _context.Categories.Update(categoryToEdit);
                await _context.SaveChangesAsync();
            }
        }
    }
}