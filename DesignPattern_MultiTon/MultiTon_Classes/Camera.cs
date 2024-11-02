using System;

namespace DesignPattern_MultiTon.MultiTon_Classes
{
    public sealed class Camera
    {
        private static volatile Dictionary<string, Camera> _instanses = new Dictionary<string, Camera>();
        private static object _lock = new object();

        // Private constructor to prevent direct instantiation
        private Camera() { }

        public static Camera GetInstanse(string key)
        {
            if (!_instanses.ContainsKey(key))// this outer condition is for next threads that don't need to lock.(optional)
            {
                lock (_lock)// Handling multi threads
                {
                    if (!_instanses.ContainsKey(key))
                    {
                        _instanses.Add(key, new Camera());
                    }
                }
            }

            return _instanses[key];
        }


    }
}
