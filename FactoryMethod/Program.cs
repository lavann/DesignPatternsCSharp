// See https://aka.ms/new-console-template for more information
using FactoryMethod;

Console.WriteLine("Factory Method!");

CarFactory sedanFactory = new SedanFactory();
ICar sedan = sedanFactory.CreateCar();
Console.WriteLine(sedan.GetCarType()); // Output: Sedan

CarFactory hatchbackFactory = new HatchbackFactory();
ICar hatchback = hatchbackFactory.CreateCar();
Console.WriteLine(hatchback.GetCarType()); // Output: Hatchback

CarFactory suvFactory = new SUVFactory();
ICar suv = suvFactory.CreateCar();
Console.WriteLine(suv.GetCarType()); // Output: SUV

Console.ReadLine();


//consider a car manufacturing company that produces different types of cars, such as sedans, hatchbacks, and SUVs.
//We can use the Factory Method pattern to create these different car types based on their individual requirements
namespace FactoryMethod
{


    // Define a common interface for all car types.
    public interface ICar
    {
        string GetCarType();
    }

    // Implement concrete car classes that implement ICar.
    public class Sedan : ICar
    {
        public string GetCarType()
        {
            return "Sedan";
        }
    }

    public class Hatchback : ICar
    {
        public string GetCarType()
        {
            return "Hatchback";
        }
    }

    public class SUV : ICar
    {
        public string GetCarType()
        {
            return "SUV";
        }
    }

    // Define the abstract CarFactory class with the Factory Method.
    public abstract class CarFactory
    {
        public abstract ICar CreateCar();
    }

    // Implement concrete factory classes for each car type.
    public class SedanFactory : CarFactory
    {
        public override ICar CreateCar()
        {
            return new Sedan();
        }
    }

    public class HatchbackFactory : CarFactory
    {
        public override ICar CreateCar()
        {
            return new Hatchback();
        }
    }

    public class SUVFactory : CarFactory
    {
        public override ICar CreateCar()
        {
            return new SUV();
        }
    }

}