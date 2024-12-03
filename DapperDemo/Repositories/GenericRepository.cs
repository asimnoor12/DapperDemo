
using System.Data;
using Dapper;
using System.Linq.Expressions;
using DapperDemo.Data;
using DapperDemo.Models;

namespace DapperDemo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public GenericRepository(Database database)
        {
            _dbConnection = database.CreateConnection();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM [Product]";
            return await _dbConnection.QueryAsync<T>(query);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM [Product] WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<int> AddAsync(T entity)
        {
            var query = "INSERT INTO [Product] (Name, Category, Price, Stock) " +
                        "VALUES (@Name, @Category, @Price, @Stock)";

            var parameters = new DynamicParameters();

            var product = entity as Product; // assuming the entity is of type Product
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Category", product.Category, DbType.String);
            parameters.Add("Price", product.Price, DbType.Decimal);
            parameters.Add("Stock", product.Stock, DbType.Int32);

            return await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var query = "UPDATE [Product] " +
                        "SET Name = @Name, Category = @Category, Price = @Price, Stock = @Stock " +
                        "WHERE Id = @Id";

            var parameters = new DynamicParameters();

            var product = entity as Product; 
            parameters.Add("Id", product.Id, DbType.Int32);       // Adding the Id for the WHERE clause
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Category", product.Category, DbType.String);
            parameters.Add("Price", product.Price, DbType.Decimal);
            parameters.Add("Stock", product.Stock, DbType.Int32);

            return await _dbConnection.ExecuteAsync(query, parameters);
        }


        public async Task<int> DeleteAsync(int id)
        {
            var query = $"DELETE FROM [{typeof(T).Name}] WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}

