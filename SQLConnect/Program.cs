using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLClass sql = new SQLClass();
            sql.OpenConnection();
            string TableName = Console.ReadLine();

            SqlCommand commandselect = new SqlCommand(@"select * from @tablename; select * from Books;", sql.GetConnection());
            SqlParameter parameterTableName = new SqlParameter();
            parameterTableName.ParameterName = "tablename";
            parameterTableName.SqlDbType = System.Data.SqlDbType.NVarChar;
            parameterTableName.Value = TableName;
            commandselect.Parameters.Add(parameterTableName);
            //commandselect.Parameters.AddWithValue(TableName, parameterTableName);
            //sql.InsertCommand("insert into Books values (1003,'451C farengeit',400,150);");
            SqlDataReader reader;
            reader = commandselect.ExecuteReader();
            do {
                if (reader != null)
                { 
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[2].ToString());
                    }
                }
            } 
            while ((reader = commandselect.ExecuteReader()) != null);
            reader.Close();
            string NameBook = "451C farengeit; drop table Authors;";
            //sql.InsertCommand("insert into Books values (1003,'"+ NameBook + "',400,150);");
            //command.ExecuteReader();
            sql.CloseConnection();
            Console.ReadLine();
        }
    }
}
