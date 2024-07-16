using System;
using System.Data;
using System.Data.SqlClient;

namespace ThuVien
{
    public class XuLy
    {
        private string connectionString;

        public XuLy(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = CreateConnection();
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Thay vì Console.WriteLine, có thể xử lý lỗi theo cách khác
                Console.WriteLine(ex.Message);
            }
            return dataTable;
        }

        public bool ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Thay vì Console.WriteLine, có thể xử lý lỗi theo cách khác
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
