using DemoApiFramework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Web;

namespace DemoApiFramework.Services
{
    public class StudentService
    {
        private SqlConnection _connection;
        private string connectionString;

        public StudentService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["maConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection c = _connection)
            {

                c.Open();
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM student";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Student
                            {
                                student_id = (int)reader["student_id"],
                                first_name = reader["first_name"].ToString(),
                                last_name = reader["last_name"].ToString(),
                                year_result = (int)reader["year_result"]
                            };
                        }
                    }
                }
            }
        }
        public void Save(Student s)
        {
            using (SqlConnection c = _connection)
            {

                c.Open();
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO student (student_id, first_name, last_name, year_result, course_id) VALUES (@student_id, @first_name, @last_name, @year_result, @course)";
                    cmd.Parameters.AddWithValue("student_id", s.student_id);
                    cmd.Parameters.AddWithValue("first_name", s.first_name);
                    cmd.Parameters.AddWithValue("last_name", s.last_name);
                    cmd.Parameters.AddWithValue("year_result", s.year_result);
                    cmd.Parameters.AddWithValue("course", "azerty");
                    cmd.ExecuteNonQuery();
                }

            }

        }

    } 
}