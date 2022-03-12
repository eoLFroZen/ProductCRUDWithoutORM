using MySql.Data.MySqlClient;
using Product_Without_ORM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Without_ORM.Data
{
    public class ProductData : IProductData
    {
        public List<Product> GetAll()
        {
            MySqlConnection mySqlConnection = Database.GetConnection();
            mySqlConnection.Open();

            List<Product> products = new List<Product>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM products";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Price = reader.GetDecimal(2);
                    product.Stock = reader.GetInt32(3);

                    products.Add(product);
                }
            }

            return products;
        }

        public Product GetById(int id)
        {
            MySqlConnection mySqlConnection = Database.GetConnection();
            mySqlConnection.Open();

            Product product = new Product();
            using (mySqlConnection)
            {
                string sql = "SELECT * FROM products " +
                    "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Price = reader.GetDecimal(2);
                    product.Stock = reader.GetInt32(3);
                }
            }

            return product;
        }

        public void Add(Product product)
        {
            MySqlConnection mySqlConnection = Database.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO products(name, price, stock) " +
                    "VALUES (@name, @price, @stock)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Product product)
        {
            MySqlConnection mySqlConnection = Database.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "UPDATE products " +
                    "SET name = @name, price = @price, stock = @stock " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", product.Id);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            MySqlConnection mySqlConnection = Database.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM products " +
                    "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
