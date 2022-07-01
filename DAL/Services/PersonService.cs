using DAL.Entities;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class PersonService
    {
        public string ConnectionString
        {
            get { return "server=localhost\\SQLEXPRESS;database=TaskADO;integrated security=true"; }
        }

        public IEnumerable<Person> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, LastName, FirstName FROM Person";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person()
                    {
                        Id = (int)reader["Id"],
                        LastName = (string)reader["LastName"],
                        FirstName = (string)reader["FirstName"],
                    };

                    yield return person;
                }
            }
        }

        public Person GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, LastName, FirstName FROM Person WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Person()
                {
                    Id = (int)reader["Id"],
                    LastName = (string)reader["LastName"],
                    FirstName = (string)reader["FirstName"]
                };
            }
        }

        public int AddPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Person (LastName, FirstName) VALUES (@lastName, @firstName)";
                command.Parameters.AddWithValue("lastName", person.LastName);
                command.Parameters.AddWithValue("firstName", person.FirstName);

                return command.ExecuteNonQuery();
            }
        }

        public int DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Person WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery();
            }
        }

        public int Update(Person person)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Person SET LastName = @lastname, FirstName = @firstname WHERE Id = @id";
                command.Parameters.AddWithValue("lastname", person.LastName);
                command.Parameters.AddWithValue("firstname", person.FirstName);
                command.Parameters.AddWithValue("id", person.Id);
                return command.ExecuteNonQuery();
            }
        }
    }
}
