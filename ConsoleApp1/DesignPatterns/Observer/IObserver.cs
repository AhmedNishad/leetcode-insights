using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DesignPatterns.Observer
{
    public interface IObserver
    {
        void ReceiveNotification(object obj);
    }
}
