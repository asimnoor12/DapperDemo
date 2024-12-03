using DapperDemo.Models;

namespace DapperDemo.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }
}
