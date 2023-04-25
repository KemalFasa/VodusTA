using VodusTA.Entities;

using System.Threading.Tasks;

namespace VodusTA.DbContext.Interfaces
{
    public interface IProductDbContext
    {
        Task<Product> GetAllProduct();
         Task<bool> CreateProduct(Product product);
      
    }
}
