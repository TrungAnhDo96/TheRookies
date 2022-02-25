using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RK_A11.DTO;

namespace RK_A11.Interface
{
    public interface ICategoryService
    {
        public Task AddCategory(CategoryDTO dto);

        public Task UpdateCategory(int id, CategoryDTO dto);

        public Task DeleteCategory(int id);

        public Task<CategoryDTO> GetCategory(int id);

        public Task<List<CategoryDTO>> GetAllCategories();
    }
}