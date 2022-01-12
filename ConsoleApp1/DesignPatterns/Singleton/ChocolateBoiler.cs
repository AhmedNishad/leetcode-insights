using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DesignPatterns.Singleton
{
    public class ChocolateBoiler
    {
        private bool empty;
        private bool boiled;
        private static ChocolateBoiler _instance;
        public ChocolateBoiler()
        {
            empty = false;
            boiled = false;
        }

        public static ChocolateBoiler GetInstance()
        {
            if (_instance == null)
                _instance = new ChocolateBoiler();

            return _instance;
        }
    }
}
