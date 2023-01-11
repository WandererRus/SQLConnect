using System.Data.SqlClient;

namespace SQLConnect
{
    internal class SQLClass
    {
        SqlConnection connection = null;
        public SQLClass()
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Library;Integrated Security = True;";
            connection = new SqlConnection(connectionString);
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public void InsertCommand(string commandString)
        {
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
        }
    }
}
