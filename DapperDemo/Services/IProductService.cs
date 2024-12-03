using DapperDemo.Models;

namespace DapperDemo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }
}
