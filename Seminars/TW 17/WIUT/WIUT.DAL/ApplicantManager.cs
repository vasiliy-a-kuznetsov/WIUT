using System.Data;
using System.Data.SQLite;

namespace WIUT.DAL
{
    public partial class ApplicantManager : DbManager
    {
        public void Create(Applicant a)
        {
            using var connection = Connection;
            try
            {
                var sql = @"
INSERT INTO Applicant
           (Name
           ,Surname
           ,Address
           ,DoB
           ,IsMarried
           ,PassportNo
           ,CourseId)
     VALUES
           (@name
           ,@surname
           ,@address
           ,@dob
           ,@isMarried
           ,@passportNo
           ,@courseId)";

                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("name", a.Name);
                command.Parameters.AddWithValue("surname", a.Surname);
                command.Parameters.AddWithValue("address", a.Address);
                command.Parameters.AddWithValue("dob", a.DoB.Ticks);
                command.Parameters.AddWithValue("isMarried", Convert.ToInt32(a.IsMarried));
                command.Parameters.AddWithValue("passportNo", a.PassportNo);
                command.Parameters.AddWithValue("courseId", a.Course.Id);

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

        public void Update(Applicant a)
        {
            using var connection = Connection;
            try
            {
                var sql = @"
UPDATE Applicant 
   SET Name = @name
      ,Surname = @surname
      ,Address = @address
      ,DoB = @dob
      ,IsMarried = @isMarried
      ,PassportNo = @passportNo
      ,CourseId = @courseId
WHERE Id = @id";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("name", a.Name);
                command.Parameters.AddWithValue("surname", a.Surname);
                command.Parameters.AddWithValue("address", a.Address);
                command.Parameters.AddWithValue("dob", a.DoB.Ticks);
                command.Parameters.AddWithValue("isMarried", Convert.ToInt32(a.IsMarried));
                command.Parameters.AddWithValue("passportNo", a.PassportNo);
                command.Parameters.AddWithValue("courseId", a.Course.Id);
                command.Parameters.AddWithValue("id", a.Id);

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
                var sql = "DELETE FROM Applicant WHERE Id = @id";
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

        public Applicant GetById(int id)
        {
            using var connection = Connection;
            try
            {
                var sql = @"
SELECT Id
      ,Name
      ,Surname
      ,Address
      ,DoB
      ,IsMarried
      ,PassportNo
      ,CourseId
FROM Applicant
WHERE ID = @id";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Applicant
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = reader.GetValue(1).ToString(),
                        Surname = reader.GetValue(2).ToString(),
                        Address = reader.GetValue(3).ToString(),
                        DoB = new DateTime(Convert.ToInt64(reader.GetValue(4))),
                        IsMarried = Convert.ToBoolean(Convert.ToInt32(reader.GetValue(5))),
                        PassportNo = reader.GetValue(6).ToString(),
                        Course = new CourseManager().GetById(Convert.ToInt32(reader.GetValue(7)))
                    };
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

        public List<Applicant> GetAll()
        {
            using var connection = Connection;
            var result = new List<Applicant>();
            try
            {
                var sql = @"
SELECT Id
      ,Name
      ,Surname
      ,Address
      ,DoB
      ,IsMarried
      ,PassportNo
      ,CourseId
FROM Applicant";
                var command = new SQLiteCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var a = new Applicant
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = reader.GetValue(1).ToString(),
                        Surname = reader.GetValue(2).ToString(),
                        Address = reader.GetValue(3).ToString(),
                        DoB = new DateTime(Convert.ToInt64(reader.GetValue(4))),
                        IsMarried = Convert.ToBoolean(Convert.ToInt32(reader.GetValue(5))),
                        PassportNo = reader.GetValue(6).ToString(),
                        Course = new CourseManager().GetById(Convert.ToInt32(reader.GetValue(7)))
                    };
                    result.Add(a);
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

            return result;
        }
    }
}