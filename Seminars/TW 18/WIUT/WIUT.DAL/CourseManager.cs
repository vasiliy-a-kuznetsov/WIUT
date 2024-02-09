using System.Data;
using System.Data.SQLite;

namespace WIUT.DAL
{
    public class CourseManager : DbManager
    {
        public void Create(Course c)
        {
            using var connection = Connection;
            try
            {
                var sql = "INSERT INTO Course (Name) VALUES (@name)";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("name", c.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        public void Update(Course c)
        {
            using var connection = Connection;
            try
            {
                var sql = "UPDATE Course SET Name = @name WHERE Id = @id";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("id", c.Id);
                command.Parameters.AddWithValue("name", c.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using var connection = Connection;
            try
            {
                var sql = "DELETE FROM Course WHERE Id = @id";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public Course GetById(int id)
        {
            using var connection = Connection;
            try
            {
                var sql = "SELECT Id, Name FROM Course WHERE Id = @id";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                
                connection.Open();
                
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var c = new Course
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    return c;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }

            // if we are here - something went wrong
            return null;
        }


        public List<Course> GetAll()
        {
            using var connection = Connection;
            var result = new List<Course>();
            try
            {
                var sql = "SELECT Id, Name FROM Course";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Course
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    result.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return result;
        }

    }
}
