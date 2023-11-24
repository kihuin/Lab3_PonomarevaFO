using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PonomarevaFO
{
    public class DbWorker
    {
        private string connectionString;

        public DbWorker(string serverName, string databaseName)
        {
            connectionString = $"Data Source={"DESKTOP-MQ71CVG"};Initial Catalog={"TypeTriangle1"};Integrated Security=True";
        }

        public void AddData(double length1, double length2, double length3, string triangleType, string errorMessage)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Triangle (Length1, Length2, Length3, Type, ErrorMessage) VALUES (@Length1, @Length2, @Length3, @Type, @ErrorMessage)", connection);
                    command.Parameters.AddWithValue("@Length1", length1);
                    command.Parameters.AddWithValue("@Length2", length2);
                    command.Parameters.AddWithValue("@Length3", length3);
                    command.Parameters.AddWithValue("@Type", triangleType);
                    command.Parameters.AddWithValue("@ErrorMessage", errorMessage);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Data added to the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding data to the database: " + ex.Message);
                }
            }
        }

        public List<TypeTriangle> GetData()
        {
            List<TypeTriangle> triangles = new List<TypeTriangle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Triangle", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        double length1 = Convert.ToDouble(reader["Length1"]);
                        double length2 = Convert.ToDouble(reader["Length2"]);
                        double length3 = Convert.ToDouble(reader["Length3"]);
                        string triangleType = reader["Type"].ToString();
                        string errorMessage = reader["ErrorMessage"].ToString();

                        TypeTriangle triangle = new TypeTriangle(length1, length2, length3, triangleType, errorMessage);
                        triangles.Add(triangle);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при соединении с базой данных: " + ex.Message);
                }
            }

            return triangles;
        }

        public void DeleteData(double length1, double length2, double length3)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Triangle WHERE Length1 = @Length1 AND Length2 = @Length2 AND Length3 = @Length3", connection);
                    command.Parameters.AddWithValue("@Length1", length1);
                    command.Parameters.AddWithValue("@Length2", length2);
                    command.Parameters.AddWithValue("@Length3", length3);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Data deleted from the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting data from the database: " + ex.Message);
                }
            }
        }

     
    }

    public class TypeTriangle
    {
        public double Length1 { get; set; }
        public double Length2 { get; set; }
        public double Length3 { get; set; }
        public string TriangleType { get; set; }
        public string ErrorMessage { get; set; }

        public TypeTriangle(double length1, double length2, double length3, string triangleType, string errorMessage)
        {
            Length1 = length1;
            Length2 = length2;
            Length3 = length3;
            TriangleType = triangleType;
            ErrorMessage = errorMessage;
        }
    }
}
