using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DesignPatterns.Observer
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void PushToObservers(object obj);
    }
}
