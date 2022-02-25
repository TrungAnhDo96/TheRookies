using RK_A11.DTO;
using RK_A11.Entities;

namespace RK_A11.Utilities
{
    public static class Utility
    {
        public static CategoryDTO CategoryEntityToDTO(this Category entity)
        {
            return new CategoryDTO()
            {
                CategoryName = entity.CategoryName,
            };
        }

        public static Category CategoryDTOToEntity(this CategoryDTO dto)
        {
            return new Category()
            {
                CategoryName = dto.CategoryName
            };
        }

        public static ProductDTO ProductEntityToDTO(this Product entity)
        {
            return new ProductDTO()
            {
                ProductName = entity.ProductName,
                Manufacture = entity.Manufacture,
                CategoryId = entity.CategoryId
            };
        }

        public static Product ProductDTOToEntity(this ProductDTO dto)
        {
            return new Product()
            {
                ProductName = dto.ProductName,
                Manufacture = dto.Manufacture,
                CategoryId = dto.CategoryId
            };
        }
    }
}