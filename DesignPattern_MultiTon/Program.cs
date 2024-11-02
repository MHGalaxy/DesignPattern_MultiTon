using DesignPattern_MultiTon.MultiTon_Classes;

namespace DesignPattern_MultiTon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Camera camera_A = Camera.GetInstanse("A");
            Camera camera_A2 = Camera.GetInstanse("A");
            Camera camera_B = Camera.GetInstanse("B");



            var sqlConnection = DatabaseConnection.GetInstance("SQL");
            sqlConnection.Connect();

            var oracleConnection = DatabaseConnection.GetInstance("Oracle");
            oracleConnection.Connect();

            var mongoConnection = DatabaseConnection.GetInstance("MongoDB");
            mongoConnection.Connect();

            var anotherSqlConnection = DatabaseConnection.GetInstance("SQL");
            anotherSqlConnection.Connect();

            Console.WriteLine(Object.ReferenceEquals(sqlConnection, anotherSqlConnection));  // It returns True

            sqlConnection.Disconnect();
            oracleConnection.Disconnect();
            mongoConnection.Disconnect();
        }
    }
}
