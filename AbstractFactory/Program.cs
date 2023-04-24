// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Console.WriteLine("Abstract Factory");

CarAndEngineFactory petrolSedanFactory = new PetrolSedanFactory();
ICar petrolSedan = petrolSedanFactory.CreateCar();
IEngine petrolEngine = petrolSedanFactory.CreateEngine();
Console.WriteLine($"{petrolSedan.GetCarType()}");



//extend our car manufacturing company example to produce cars with different engines, such as petrol, diesel, and electric engines.
//We can use the Abstract Factory pattern to create families of related objects, like car types and their corresponding engines.
namespace AbstractFactory
{

    // Define common interfaces for cars and engines.
    public interface ICar
    {
        string GetCarType();
    }

    public interface IEngine
    {
        string GetEngineType();
    }

    // Implement concrete car classes.
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

    // Implement concrete engine classes.
    public class PetrolEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Petrol";
        }
    }

    public class DieselEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Diesel";
        }
    }

    public class ElectricEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Electric";
        }
    }

    // Define the abstract CarAndEngineFactory class with abstract methods for creating cars and engines.
    public abstract class CarAndEngineFactory
    {
        public abstract ICar CreateCar();
        public abstract IEngine CreateEngine();
    }

    // Implement concrete factory classes for different combinations of cars and engines.
    public class PetrolSedanFactory : CarAndEngineFactory
    {
        public override ICar CreateCar()
        {
            return new Sedan();
        }

        public override IEngine CreateEngine()
        {
            return new PetrolEngine();
        }
    }

    public class ElectricHatchbackFactory : CarAndEngineFactory
    {
        public override ICar CreateCar()
        {
            return new Hatchback();
        }

        public override IEngine CreateEngine()
        {
            return new ElectricEngine();
        }
    }

    public class DieselSUVFactory : CarAndEngineFactory
    {
        public override ICar CreateCar()
        {
            return new SUV();
        }

        public override IEngine CreateEngine()
        {
            return new DieselEngine();
        }
    }

}

