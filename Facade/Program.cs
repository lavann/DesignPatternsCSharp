// See https://aka.ms/new-console-template for more information

using Facade;
Console.WriteLine("Facade");
//use the CarAssemblyFacade to assemble a car without directly interacting with the underlying subsystems
CarAssemblyFacade carAssemblyFacade = new CarAssemblyFacade();
carAssemblyFacade.AssembleCar();


//onsider a scenario where our car manufacturing company wants to simplify the process of assembling a car.
//The car assembly process involves multiple subsystems, such as the engine, transmission, and electrical systems.
//We can use the Facade pattern to provide a simple interface for assembling a car without exposing the complexity of the underlying subsystems
namespace Facade
{

    // define subsystems of a car
    public class Engine
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling engine");
        }
    }

    public class Transmission
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling transmission");
        }
    }

    public class ElectricalSystem
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling electrical system");
        }
    }

    // create the Assemnly Facade Class
    public class CarAssemblyFacade
    {
        private readonly Engine _engine;
        private readonly Transmission _transmission;
        private readonly ElectricalSystem _electricalSystem;

        public CarAssemblyFacade()
        {
            _engine = new Engine();
            _transmission = new Transmission();
            _electricalSystem = new ElectricalSystem();
        }

        public void AssembleCar()
        {
            Console.WriteLine("Assembling car");
            _engine.Assemble();
            _transmission.Assemble();
            _electricalSystem.Assemble();
            Console.WriteLine("Car assembly completed");
        }
    }


}