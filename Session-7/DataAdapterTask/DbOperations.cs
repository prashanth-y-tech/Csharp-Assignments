using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAdapterTask
{
    public class DBOperations
    {
        private readonly string _connectionString;
        public DBOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GetData()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter sde = new SqlDataAdapter("SELECT * FROM USERS;", conn);
                DataSet usersDataSet = new DataSet();
                sde.Fill(usersDataSet);
                foreach(DataColumn coloumn in usersDataSet.Tables[0].Columns)
                {
                    Console.Write($"{coloumn.ColumnName}\t\t\t\t");
                }
                foreach (DataRow row in usersDataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"{row[0]}\t {row[1]}\t\t {row[2]}\t\t\t\t {row[3]} ");
                }
            }
        }
    }
}
