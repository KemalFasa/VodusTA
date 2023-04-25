using Dapper;
using VodusTA.Entities;
using VodusTA.DbContext.Interfaces;
      
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace VodusTA.DbContext
{
    public class ProductDbContext : IProductDbContext
    {
        private readonly IConfiguration _configuration;

          public async Task<List<Product>> GetAllProduct()
        {            
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var product = await connection.QueryAsync<Product>
                ("SELECT * FROM Product ");

    
            return product.ToList();
        }

           public async Task<bool> CreateProduct(Product product)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                            new { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price });
                                
            if (affected == 0)
                return false;

            return true;
        }
    }
}
