// See https://aka.ms/new-console-template for more information

using Decorator;

Car basicCar = new BasicCar();

//dynamically add optional features to a car using the Decorator pattern
Car carWithNavigation = new NavigationSystem(basicCar);
Car carWithNavigationAndSunroof = new Sunroof(carWithNavigation);
Car fullyLoadedCar = new LeatherSeats(carWithNavigationAndSunroof);

Console.WriteLine($"{basicCar.GetDescription()} - Cost: ${basicCar.GetCost()}"); // Output: Basic car - Cost: $20000
Console.WriteLine($"{carWithNavigation.GetDescription()} - Cost: ${carWithNavigation.GetCost()}"); // Output: Basic car, Navigation System - Cost: $21500
Console.WriteLine($"{carWithNavigationAndSunroof.GetDescription()} - Cost: ${carWithNavigationAndSunroof.GetCost()}"); // Output: Basic car, Navigation System, Sunroof - Cost: $22700
Console.WriteLine($"{fullyLoadedCar.GetDescription()} - Cost: ${fullyLoadedCar.GetCost()}"); // Output: Basic car, Navigation System, Sunroof, Leather Seats - Cost: $24700

Console.WriteLine("Hello, World!");



//consider a scenario where our car manufacturing company wants to add optional features to a car, such as a navigation system, sunroof, or leather seats.
//We can use the Decorator pattern to dynamically add these optional features to a car without modifying the existing Car class.
namespace Decorator
{

    //Define car
    public abstract class Car
    {
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    // Define concrete car (basic car)
    public class BasicCar : Car
    {
        public override string GetDescription()
        {
            return "Basic car";
        }

        public override double GetCost()
        {
            return 20000;
        }
    }


    // Define abstract decorator class
    public abstract class CarDecorator : Car
    {
        protected Car DecoratedCar;

        protected CarDecorator(Car car)
        {
            DecoratedCar = car;
        }
    }

    // Define concrete decorator classes
    // create concrete decorator classes for each optional feature.
    public class NavigationSystem : CarDecorator
    {
        public NavigationSystem(Car car) : base(car) { }

        public override string GetDescription()
        {
            return DecoratedCar.GetDescription() + ", Navigation System";
        }

        public override double GetCost()
        {
            return DecoratedCar.GetCost() + 1500;
        }
    }

    public class Sunroof : CarDecorator
    {
        public Sunroof(Car car) : base(car) { }

        public override string GetDescription()
        {
            return DecoratedCar.GetDescription() + ", Sunroof";
        }

        public override double GetCost()
        {
            return DecoratedCar.GetCost() + 1200;
        }
    }

    public class LeatherSeats : CarDecorator
    {
        public LeatherSeats(Car car) : base(car) { }

        public override string GetDescription()
        {
            return DecoratedCar.GetDescription() + ", Leather Seats";
        }

        public override double GetCost()
        {
            return DecoratedCar.GetCost() + 2000;
        }
    }




}