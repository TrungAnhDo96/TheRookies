using RK_A11.DTO;

namespace RK_A11.Interface
{
    public interface IProductService
    {
        public Task AddProduct(ProductDTO dto);

        public Task UpdateProduct(int id, ProductDTO dto);

        public Task DeleteProduct(int id);

        public Task<ProductDTO> GetProduct(int id);

        public Task<List<ProductDTO>> GetAllProducts();
    }
}