// ObserverPattern.
// A design pattern allowing an 'observer' to subscribe to something that is 'observerable'. 
// For example: a cell broadcast alarm service. The alarm service in this case is the thing that 
// is 'observerable'. The 'observers' are cell-phone that can subscribe (attach) to the service. They are then,
// added to a list of subscribers (or observers). 
// In case of an alarm, the alarm service (observerable) notifies all observers the list.

using System;
using System.Text;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myWeatherStation = new Subject("MyWeatherStation");
            var myThermometer = new Observer("MyThermometer");
            myWeatherStation.Attact(myThermometer);
            myWeatherStation.Notify();

            myWeatherStation.Temperature = 40;
            myWeatherStation.Notify();

            Console.ReadLine();
        }
    }

    public interface ISubject
    {
        public int Temperature { get; set; }

        void Attact(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public string Name {get; set;}

        public int Temperature {get; set;} = 20;

        public Subject(string name)
        {
            Name = name;
        }

        private List<IObserver> observers = new List<IObserver>();

        public void Attact(IObserver observer)
        {
            Console.WriteLine($"Subject: [{Name}] attached to observer: [{observer.Name}]");
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {   
            Console.WriteLine($"Subject: [{Name}] detached from observer: [{observer.Name}]");
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                Console.WriteLine($"Subject: [{Name}] notifying observer: [{observer.Name}]. Temperature is now: [{Temperature}] degrees");
                observer.Update();
            }
        }
    }

    public interface IObserver
    {   
        string Name {get; set;}
        
        void Update();
    }

    public class Observer : IObserver
    {
        public string Name { get; set; }

        public Observer(string name)
        {
            Name = name;
        }

        public void Update()
        {
            Console.WriteLine($"Subject: [{Name}] changed state!");
        }
    }
}

// Outputs:
// Subject: [MyWeatherStation] attached to observer: [MyThermometer]
// Subject: [MyWeatherStation] notifying observer: [MyThermometer]. Temperature is now: [20] degrees
// Subject: [MyThermometer] changed state!
// Subject: [MyWeatherStation] notifying observer: [MyThermometer]. Temperature is now: [40] degrees
// Subject: [MyThermometer] changed state!
