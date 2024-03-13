using AdoNetDemo.Business.Concrete;
using AdoNetDemo.DataAccess.Abstract;
using AdoNetDemo.DataAccess.Concrete;
using AdoNetDemo.Entities;
using AdoNetDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace AdoNetDemo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SqlConnection connection = new SqlConnection("Server=ASLIYILMAZ\\SQLEXPRESS; Database=Store; User Id=sa; Password=12345");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<ProductModel> products = new List<ProductModel>();
            while (reader.Read())
            {
                ProductModel product = new ProductModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }
            reader.Close();
            connection.Close();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel pm)
        {
            SqlConnection connection = new SqlConnection("Server=ASLIYILMAZ\\SQLEXPRESS; Database=Store; User Id=sa; Password=12345");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (Name, UnitPrice) VALUES (@Name, @UnitPrice)", connection);
            cmd.Parameters.AddWithValue("@Name", pm.Name);
            cmd.Parameters.AddWithValue("@UnitPrice", pm.UnitPrice);
            cmd.ExecuteNonQuery();

            connection.Close();
            return Ok(pm);
        }
    }
}
