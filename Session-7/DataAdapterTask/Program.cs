using System;
using System.Configuration;

namespace DataAdapterTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;
            DBOperations dB = new DBOperations(connectionString);
            dB.GetData();
            Console.ReadLine();
        }
    }
}
