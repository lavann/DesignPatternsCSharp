// See https://aka.ms/new-console-template for more information
using BridgePattern;
Console.WriteLine("Hello, World!");

IEngine gasolineEngine = new GasolineEngine();
IEngine electricEngine = new ElectricEngine();

Car sedanWithGasolineEngine = new Sedan(gasolineEngine);
Car sedanWithElectricEngine = new Sedan(electricEngine);
Car suvWithGasolineEngine = new SUV(gasolineEngine);
Car suvWithElectricEngine = new SUV(electricEngine);

sedanWithGasolineEngine.StartCar(); // Output: Sedan: Gasoline engine started
sedanWithElectricEngine.StartCar(); // Output: Sedan: Electric engine started
suvWithGasolineEngine.StartCar();   // Output: SUV: Gasoline engine started
suvWithElectricEngine.StartCar();   // Output: SUV: Electric engine started


//consider a scenario where our car manufacturing company has different types of cars (Sedan, SUV) and each type can have different types of engines (Gasoline, Electric).
//We can use the Bridge pattern to separate the car types from the engines so that they can evolve independently.

namespace BridgePattern
{
    public interface IEngine
    {
        string StartEngine();
    }

    public class GasolineEngine : IEngine
    {
        public string StartEngine()
        {
            return "Gasoline engine started";
        }
    }

    public class ElectricEngine : IEngine
    {
        public string StartEngine()
        {
            return "Electric engine started";
        }
    }


    public abstract class Car
    {
        protected IEngine Engine;

        protected Car(IEngine engine)
        {
            Engine = engine;
        }

        public abstract void StartCar();
    }

    public class Sedan : Car
    {
        public Sedan(IEngine engine) : base(engine) { }

        public override void StartCar()
        {
            Console.WriteLine($"Sedan: {Engine.StartEngine()}");
        }
    }

    public class SUV : Car
    {
        public SUV(IEngine engine) : base(engine) { }

        public override void StartCar()
        {
            Console.WriteLine($"SUV: {Engine.StartEngine()}");
        }
    }


}