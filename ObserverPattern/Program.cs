using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    // https://www.youtube.com/watch?v=oVAFvyICmbw
    class Program
    {
        static void Main(string[] args)
        {
            var weatherStation = new WeatherStation();

            var newsChannel1 = new NewsChannel("Independence TV");
            weatherStation.AddObserver(newsChannel1);

            var newsChannel2 = new NewsChannel("India Tomorrow");
            weatherStation.AddObserver(newsChannel2);

            weatherStation.Temperature = 10.2f;
            weatherStation.Temperature = 23.2f;
            weatherStation.Temperature = 45.2f;


        }
    }

    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notify();

    }

    public class WeatherStation : ISubject
    {
        List<IObserver> observers;
        float _temp;
        public float Temperature
        {
            get
            {
                return this._temp;
            }

            set
            {
                this._temp = value;
                Notify();
            }
        }
        public WeatherStation()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Notify()
        {
            observers.ForEach(
                o => o.Update(this));
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }
    }

    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public class NewsChannel : IObserver
    {
        string name;
        public NewsChannel(string name)
        {
            this.name = name;
        }
        public void Update(ISubject subject)
        {
            WeatherStation station = subject as WeatherStation;

            if (station is WeatherStation)
            {
                Console.WriteLine("{0} News Channel has updated temprature as {1}", this.name, station.Temperature);
            }

        }
    }
}
