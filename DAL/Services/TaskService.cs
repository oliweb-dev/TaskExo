using System.Data.SqlClient;
using E = DAL.Entities;

namespace DAL.Services
{
    public class TaskService
    {
        public string ConnectionString
        {
            get { return "server=localhost\\SQLEXPRESS;database=TaskADO;integrated security=true"; }
        }

        public IEnumerable<E.Task> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, DateCreate, DateExpectedEnd, DateEnd, CategoryId, PersonId  FROM Task";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    E.Task task = new E.Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        DateCreate = (DateTime)reader["DateCreate"],
                        DateExpectedEnd = (DateTime)reader["DateExpectedEnd"],
                        DateEnd = reader["DateEnd"] as DateTime?,
                        CategoryId = (int)reader["CategoryId"],
                        PersonId = (int)reader["PersonId"]
                    };

                    yield return task;
                }
            }
        }

        public E.Task GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, DateCreate, DateExpectedEnd, DateEnd, CategoryId, PersonId FROM Task WHERE Id = @id ORDER BY DateCreate DESC";
                command.Parameters.AddWithValue("id", id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new E.Task()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    DateCreate = (DateTime)reader["DateCreate"],
                    DateExpectedEnd = (DateTime)reader["DateExpectedEnd"],
                    DateEnd = reader["DateEnd"] as DateTime?,
                    CategoryId = (int)reader["CategoryId"],
                    PersonId = (int)reader["PersonId"]
                };
            }
        }

        public IEnumerable<E.Task> GetByCategoryId(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, DateCreate, DateExpectedEnd, DateEnd, CategoryId, PersonId FROM Task WHERE CategoryId = @categoryId ORDER BY DateCreate DESC";
                command.Parameters.AddWithValue("categoryId", categoryId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    E.Task task = new E.Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        DateCreate = (DateTime)reader["DateCreate"],
                        DateExpectedEnd = (DateTime)reader["DateExpectedEnd"],
                        DateEnd = reader["DateEnd"] as DateTime?,
                        CategoryId = (int)reader["CategoryId"],
                        PersonId = (int)reader["PersonId"]
                    };

                    yield return task;
                }
            }
        }

        public IEnumerable<E.Task> GetByPersonId(int personId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, DateCreate, DateExpectedEnd, DateEnd, CategoryId, PersonId FROM Task WHERE PersonId = @personId ORDER BY DateCreate DESC";
                command.Parameters.AddWithValue("personId", personId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    E.Task task = new E.Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        DateCreate = (DateTime)reader["DateCreate"],
                        DateExpectedEnd = (DateTime)reader["DateExpectedEnd"],
                        DateEnd = reader["DateEnd"] as DateTime?,
                        CategoryId = (int)reader["CategoryId"],
                        PersonId = (int)reader["PersonId"]
                    };

                    yield return task;
                }
            }
        }

        public IEnumerable<E.Task> GetUnfinishedTask()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, DateCreate, DateExpectedEnd, DateEnd, CategoryId, PersonId FROM Task WHERE DateEnd IS NULL ORDER BY DateCreate DESC";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    E.Task task = new E.Task()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        DateCreate = (DateTime)reader["DateCreate"],
                        DateExpectedEnd = (DateTime)reader["DateExpectedEnd"],
                        DateEnd = reader["DateEnd"] as DateTime?,
                        CategoryId = (int)reader["CategoryId"],
                        PersonId = (int)reader["PersonId"]
                    };

                    yield return task;
                }
            }
        }

        public int AddTask(E.Task task)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Task (Name, Description, DateCreate, DateExpectedEnd, CategoryId, PersonId) VALUES (@name, @description, @dateCreate, @dateExpectedEnd, @categoryId, @personId)";
                command.Parameters.AddWithValue("name", task.Name);
                command.Parameters.AddWithValue("description", task.Description);
                command.Parameters.AddWithValue("dateCreate", task.DateCreate);
                command.Parameters.AddWithValue("dateExpectedEnd", task.DateExpectedEnd);
                command.Parameters.AddWithValue("categoryId", task.CategoryId);
                command.Parameters.AddWithValue("personId", task.PersonId);
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM task WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery();
            }
        }

        public int Update(E.Task task)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE task SET Name = @name, Description = @description, DateCreate = @dateCreate, DateExpectedEnd = @dateExpectedEnd, DateEnd = @dateEnd, CategoryId = @categoryId, PersonId = @personId WHERE Id = @id";

                command.Parameters.AddWithValue("name", task.Name);
                command.Parameters.AddWithValue("description", task.Description);
                command.Parameters.AddWithValue("dateCreate", task.DateCreate);
                command.Parameters.AddWithValue("dateExpectedEnd", task.DateExpectedEnd);
                command.Parameters.AddWithValue("dateEnd", task.DateEnd);
                command.Parameters.AddWithValue("categoryId", task.CategoryId);
                command.Parameters.AddWithValue("personId", task.PersonId);
                command.Parameters.AddWithValue("id", task.Id);

                return command.ExecuteNonQuery();
            }
        }
    }
}
