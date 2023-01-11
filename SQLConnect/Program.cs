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
            SqlCommand commandselect = new SqlCommand("select * from Authors; select * from Books;", sql.GetConnection());
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
            //sql.InsertCommand("insert into Books values (1003,'451C farengeit',400,150);");
            //command.ExecuteReader();
            sql.CloseConnection();
            Console.ReadLine();
        }
    }
}
