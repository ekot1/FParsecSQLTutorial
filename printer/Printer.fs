module Printer
open Parser

let getStruct columns table query =
    let fields = List.fold (fun acc field -> acc + (if acc = "" then "" else "\r\n") + "        public object " + field + " { get { return _reader[\"" + field + "\"]; } }  " ) "" columns
    sprintf @"
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CSharpTest
{
    public struct %s {
        IDataReader _reader;

        public users(SqlConnection connection)
        {
            DbCommand command = new SqlCommand(""%s"", connection);
            _reader = command.ExecuteReader();
        }
        public bool Read()
        {
            return _reader.Read();
        }
%s 
    }
}" 
            table query fields 

let getCSharpDeclaration result query = 
    match result with
    | Select (columns, table) -> getStruct columns table query
