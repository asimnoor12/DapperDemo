using DapperDemo.Data;
using Dapper;
using DapperDemo.Models;
using System.Data;

namespace DapperDemo.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(Database database) : base(database)
        {
            _dbConnection = database.CreateConnection();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var query = "SELECT * FROM Product WHERE Category = @Category";
            return await _dbConnection.QueryAsync<Product>(query, new { Category = category });
        }
    }
}

