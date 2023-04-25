 using System.Net;
using Microsoft.AspNetCore.Mvc;
using VodusTA.Entities;
using VodusTA.DbContext.Interfaces;

 namespace VodusTA
 {

   
    public class ProductController : ControllerBase
     {
         private readonly IProductDbContext _DbContext;
           public async Task<List<Product>> Index()
         {
             var Product = await _DbContext.GetAllProduct();
             return Product;
        
         }
       
        public async Task<ActionResult<Product>> CreateDiscount([FromBody] Product product)
        {
            await _DbContext.CreateProduct(product);
            return CreatedAtRoute("Index", new { productName = product.Name }, product);

        }

     }

 }