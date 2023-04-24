// See https://aka.ms/new-console-template for more information

using Adapter;
Car car = new Car("Sedan", 100); // Speed is 100 km/h
ICarSpeedAdapter carAdapter = new CarAdapter(car);

double speedMph = carAdapter.GetSpeedMph(); // Speed in mph
Console.WriteLine($"Car speed: {speedMph} mph");

Console.WriteLine("Hello, World!");


//consider a scenario where our car manufacturing company has an existing Car class that provides information about a car's speed in kilometers per hour (km/h).
//Now, we have a new client who wants to work with our Car objects but needs the speed in miles per hour (mph).
//We can use the Adapter pattern to create a new class that adapts the existing Car class to provide the speed in mph without needing to change the internal workings of the Car class.

namespace Adapter
{
    public class Car
    {
        public string Model { get; set; }
        public double SpeedKmH { get; set; }

        public Car(string model, double speedKmH)
        {
            Model = model;
            SpeedKmH = speedKmH;
        }

        public double GetSpeedKmH()
        {
            return SpeedKmH;
        }
    }

    // add commentory to the interface  
    // the interface is used to define the contract for the adapter
    // the adapter will implement the interface and provide the required functionality
    // the adapter will be used to adapt the car class to the interface

    public interface ICarSpeedAdapter
    {
        double GetSpeedMph();
    }

    // add commentory to the interface  
    // the interface is used to define the contract for the adapter
    // the adapter will implement the interface and provide the required functionality
    // the adapter will be used to adapt the car class to the interface

    public class CarAdapter : ICarSpeedAdapter
    {
        private readonly Car _car;

        public CarAdapter(Car car)
        {
            _car = car;
        }

        public double GetSpeedMph()
        {
            return ConvertKmHToMph(_car.GetSpeedKmH());
        }

        private double ConvertKmHToMph(double speedKmH)
        {
            const double milesPerKilometer = 0.621371;
            return speedKmH * milesPerKilometer;
        }
    }

}

