using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CSharpTest
{
    class Program
    {
        private static void RegularQuery(SqlConnection connection)
        {
            DbCommand command = new SqlCommand("select userid, firstname from tbuser", connection);

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var userid = reader["userid"];
                    var firstname = reader["firstname"];
                    Console.WriteLine("firstname " + firstname);
                }
            }
        }

        private static void GeneratedQuery(SqlConnection connection)
        {
            users u = new users(connection);
            while (u.Read())
            {
                var userid = u.userid;
                var firstname = u.firstname;
                Console.WriteLine("firstname " + firstname);
            }
        }

        static void Main(string[] args)
        {
            SqlConnection _clientConnection = new SqlConnection("Data Source=localhost;Initial Catalog=vivodata;MultipleActiveResultSets=true;Pooling=False;User ID=sa;Password=sa");
            _clientConnection.Open();
//            RegularQuery(_clientConnection);
//            GeneratedQuery(_clientConnection);
        }
    }
}
