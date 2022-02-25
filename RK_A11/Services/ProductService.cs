using Microsoft.EntityFrameworkCore;
using RK_A11.DB;
using RK_A11.DTO;
using RK_A11.Interface;
using RK_A11.Utilities;

namespace RK_A11.Services
{
    public class ProductService : IProductService
    {
        private InventoryContext _context;
        public ProductService(InventoryContext context)
        {
            _context = context;
        }

        public async Task AddProduct(ProductDTO dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var productToAdd = dto.ProductDTOToEntity();
                await _context.AddAsync(productToAdd);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var productToDelete = await _context.Products.FindAsync(id);
                if (productToDelete != null)
                {
                    _context.Remove(productToDelete);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var allProducts = await _context.Products.Select(product => product.ProductEntityToDTO()).ToListAsync();
            return allProducts;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var foundProduct = await _context.Products.FindAsync(id);
            if (foundProduct != null)
                return foundProduct.ProductEntityToDTO();
            return null;
        }

        public async Task UpdateProduct(int id, ProductDTO dto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var foundCategory = await _context.Categories.FindAsync(dto.CategoryId);
                if (foundCategory != null)
                {
                    var foundProduct = await _context.Products.FindAsync(id);
                    if (foundProduct != null)
                    {
                        foundProduct.ProductName = dto.ProductName;
                        foundProduct.Manufacture = dto.Manufacture;
                        foundProduct.CategoryId = foundCategory.CategoryId;

                        _context.Products.Update(foundProduct);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}