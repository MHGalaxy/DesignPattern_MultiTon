using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_MultiTon.MultiTon_Classes
{
    public sealed class DatabaseConnection
    {
        private static readonly Dictionary<string, DatabaseConnection> _instances = new Dictionary<string, DatabaseConnection>();
        private static object _lock = new object();

        private string _connectionType;

        // Private constructor to prevent direct instantiation
        private DatabaseConnection(string connectionType)
        {
            _connectionType = connectionType;
            Console.WriteLine($"{_connectionType} connection created.");
        }

        // Static method to get the instance associated with a specific key
        public static DatabaseConnection GetInstance(string key)
        {
            if (!_instances.ContainsKey(key))
            {
                lock (_lock)// Handling multi threads
                {
                    if (!_instances.ContainsKey(key))
                    {
                        _instances[key] = new DatabaseConnection(key);
                    }
                }
            }
            return _instances[key];
        }


        //Other methods:

        public string Connect()
        {
           return $"Connecting to {_connectionType} database.";
        }

        public string Disconnect()
        {
            return $"Disconnecting from {_connectionType} database.";
        }

    }
}
