
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CSharpTest
{
    public struct users {
        IDataReader _reader;

        public users(SqlConnection connection)
        {
            DbCommand command = new SqlCommand("select userid, firstname from users", connection);
            _reader = command.ExecuteReader();
        }
        public bool Read()
        {
            return _reader.Read();
        }
        public object userid { get { return _reader["userid"]; } }  
        public object firstname { get { return _reader["firstname"]; } }   
    }
}