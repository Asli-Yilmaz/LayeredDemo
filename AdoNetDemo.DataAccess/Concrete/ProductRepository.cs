using AdoNetDemo.DataAccess.Abstract;
using AdoNetDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo.DataAccess.Concrete
{
    public class ProductRepository : IRepository<Product>
    {
        SqlConnection _connection = new SqlConnection("Server=ASLIYILMAZ\\SQLEXPRESS; Database=Store; User Id=sa; Password=12345");
        public void Create(Product entity)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("Insert into Products values(@name,@unitPrice)", _connection);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@unitPrice", entity.UnitPrice);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("delete from Products where Id=@id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("select * from Products", _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;
        }

        public Product GetById(int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("select * from Products where Id=@id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Product product=new Product();
            while (reader.Read())
            {

                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
               
            }
            reader.Close();
            _connection.Close();
            return product;
        }

        public void Update(Product entity)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("update Products set Name=@name, UnitPrice=@unitPrice where Id=@id", _connection);
            cmd.Parameters.AddWithValue("@id",entity.Id);
            cmd.Parameters.AddWithValue("@name",entity.Name);
            cmd.Parameters.AddWithValue("@unitPrice", entity.UnitPrice);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
        public void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
