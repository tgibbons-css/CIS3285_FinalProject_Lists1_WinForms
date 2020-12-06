using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace CIS3285_FinalProject
{
    class ShoppingItemRepository : IListRepository
    {
        // DEBT --- connection string should not be hard coded here
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FinalProjLists.mdf;Integrated Security=True;Connect Timeout=30;";
        public void createItem(ShoppingItem item)
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                // DEBT --- Skips dateAdded field which is currently not used anywhere
                string SQLtext = "INSERT INTO ShoppingItemsTable(Id, name, amount, purchasedYN) VALUES(@Id, @name, @amount, @purchasedYN)";

                using (SqlCommand command = new SqlCommand(SQLtext, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", item.Id));
                    command.Parameters.Add(new SqlParameter("name", item.Name));
                    command.Parameters.Add(new SqlParameter("amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("purchasedYN", item.PuchasedYN));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<ShoppingItem> ReadAll()
        {
            List<ShoppingItem> items = new List<ShoppingItem>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ShoppingItemsTable", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Guid id = (Guid)reader["Id"];
                        string name = reader["name"].ToString();  
                        int amount = (int)reader["amount"];    
                        int purchasedInt = (int)reader["purchasedYN"];
                        bool puchasedYN = (purchasedInt == 1);
                        items.Add(new ShoppingItem(id, name, amount, puchasedYN) );
                    }
                }
            }
            return items;
        }

        public void updateChecked(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string SQLtext = "UPDATE ShoppingItemsTable SET purchasedYN = 1 WHERE (Id = @Id)";
                using (SqlCommand command = new SqlCommand(SQLtext, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

    }
}
