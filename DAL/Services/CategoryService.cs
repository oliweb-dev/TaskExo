using DAL.Entities;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class CategoryService
    {
        public string ConnectionString
        {
            get { return "server=localhost\\SQLEXPRESS;database=TaskADO;integrated security=true"; }
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM Category";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    };

                    yield return category;
                }
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM Category WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Category()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
            }
        }

        public int AddCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO CATEGORY (Name) VALUES (@name)";
                command.Parameters.AddWithValue("name", category.Name);

                return command.ExecuteNonQuery();
            }
        }

        public int DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM CATEGORY WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery();
            }
        }
    }
}
