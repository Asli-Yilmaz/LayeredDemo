using AdoNetDemo.Business.Concrete;
using AdoNetDemo.Entities;
using AdoNetDemo.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AdoNetDemo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController2 : ControllerBase
    {
        private ProductManager _productManager = new ProductManager();
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return  _productManager.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return _productManager.Get(id);
        }
        [HttpPost]
        public async Task<Product> PostProduct(Product entity)
        {
            _productManager.Create(entity);
            return entity;
        }
        [HttpPatch]
        public async Task<Product> UpdateProduct(Product entity)
        {
            _productManager.Update(entity);
            return entity;
        }
        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
           _productManager.Delete(id);
          
        }
    }
}
