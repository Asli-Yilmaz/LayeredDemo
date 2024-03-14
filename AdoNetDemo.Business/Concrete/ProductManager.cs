using AdoNetDemo.DataAccess.Abstract;
using AdoNetDemo.DataAccess.Concrete;
using AdoNetDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo.Business.Concrete
{
    public class ProductManager
    {
        private IRepository<Product> _repository = new ProductRepository();
        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }
        public Product Get(int id)
        {
            return _repository.GetById(id);
        }
        public void Create(Product entity)
        {
            _repository.Create(entity);
        }
        public void Update(Product entity)
        {
            _repository.Update(entity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
