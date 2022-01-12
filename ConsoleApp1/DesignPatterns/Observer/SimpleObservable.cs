using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DesignPatterns.Observer
{
    public class SimpleObservableTest
    {
        public static void Test()
        {
            var simpleObservable = new SimpleObservable();
            simpleObservable.Subscribe(new SimpleObserver());
            simpleObservable.PushToObservers("string");
            simpleObservable.Subscribe(new SimpleObserver());
            simpleObservable.PushToObservers("string 2");
        }
    }
    public class SimpleObservable : IObservable
    {
        private List<IObserver> observers;

        public SimpleObservable()
        {
            observers = new List<IObserver>();
        }

        /// <summary>
        /// Notifies all the observers in the list of observers
        /// </summary>
        /// <param name="obj"></param>
        public void PushToObservers(object obj)
        {
            foreach(var ob in observers)
            {
                ob.ReceiveNotification(obj);
            }
        }

        /// <summary>
        /// Adds an observer to the list of observers
        /// </summary>
        /// <param name="observer"></param>
        public void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }
    }
}
