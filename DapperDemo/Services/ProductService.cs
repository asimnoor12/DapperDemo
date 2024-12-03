using DapperDemo.Models;
using DapperDemo.Repositories;

namespace DapperDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _productRepository.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with Id {id} does not exist.");
            }
            return product;
        }

        public Task<int> AddAsync(Product product) => _productRepository.AddAsync(product);

        public Task<int> UpdateAsync(Product product) => _productRepository.UpdateAsync(product);

        
        public async Task<int> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with Id {id} does not exist.");
            }

            return await _productRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category) => _productRepository.GetProductsByCategoryAsync(category);
    }
}
