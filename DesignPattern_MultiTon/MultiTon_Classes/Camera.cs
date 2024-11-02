using System;

namespace DesignPattern_MultiTon.MultiTon_Classes
{
    /// <summary>
    /// Imagine there are several cameras in an organization. For each camera, no more than one object should be created.
    /// This can be achieved using the Singleton pattern; however, it would require creating a separate Singleton class for each camera.
    /// Using the Multiton pattern, we can create multiple controlled instances for each camera instead.
    /// </summary>
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
