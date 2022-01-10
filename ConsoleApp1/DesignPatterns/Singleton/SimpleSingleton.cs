using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DesignPatterns.Singleton
{
    public class SimpleSingleton
    {
        private static SimpleSingleton _instance;
        private SimpleSingleton()
        {

        }

        public static SimpleSingleton GetInstance()
        {
            if (_instance != null)
                return _instance;

            return new SimpleSingleton();
        }

    }
}
