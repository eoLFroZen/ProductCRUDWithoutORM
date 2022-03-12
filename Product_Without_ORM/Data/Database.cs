using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Without_ORM.Data
{
    public static class Database
    {
        private const string ConnectionString = "Server=localhost;Database=product_db;Uid=root;Pwd=1234;";

        static Database()
        {
            MySqlConnection connection = GetConnection();
            connection.Open();

            using (connection)
            {
                string sql = "CREATE TABLE IF NOT EXISTS products( " +
    "id INT PRIMARY KEY AUTO_INCREMENT,          " +
    "name VARCHAR(50) NOT NULL,                  " +
    "price DECIMAL(15, 2),                       " +
    "stock INT                                   " +
    ")";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }


        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
