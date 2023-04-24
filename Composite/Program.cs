// See https://aka.ms/new-console-template for more information
using Composite;


Console.WriteLine("Hello, World!");

/*
 * By using the Composite pattern, we can represent a hierarchy of car components and treat individual parts and groups of parts uniformly. 
 * This approach simplifies client code and makes it easier to work with complex structures.
 */
ICarComponent engine = new CarPart("Engine");
ICarComponent transmission = new CarPart("Transmission");
ICarComponent wheel = new CarPart("Wheel");

CarGroup powertrain = new CarGroup("Powertrain");
powertrain.AddComponent(engine);
powertrain.AddComponent(transmission);

CarGroup chassis = new CarGroup("Chassis");
chassis.AddComponent(wheel);

CarGroup car = new CarGroup("Car");
car.AddComponent(powertrain);
car.AddComponent(chassis);



car.DisplayInfo();


Console.WriteLine("Mix");

CarComponentFactory factory = CarComponentFactory.Instance;

ICarComponent MixCarPartEngine = factory.CreateCarPart("Brakes");
ICarComponent MixCarPartWhieel = factory.CreateCarPart("Wheel");

CarGroup MixChassisGroup = factory.CreateCarGroup("Chassis");
MixChassisGroup.AddComponent(MixCarPartEngine);
MixChassisGroup.AddComponent(MixCarPartWhieel);


CarGroup MixCar = factory.CreateCarGroup("Car");
MixCar.AddComponent(MixChassisGroup);
MixCar.DisplayInfo();

Console.ReadLine();


//consider a scenario where our car manufacturing company wants to represent a hierarchy of car components,
//where a component can be either a single part or a group of parts. We can use the Composite pattern to treat individual parts and groups of parts uniformly.
namespace Composite
{

    public interface ICarComponent
    {
        void DisplayInfo();
    }

    public class CarPart : ICarComponent
    {
        private readonly string _name;

        public CarPart(string name)
        {
            _name = name;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car part: {_name}");
        }
    }

    public class CarGroup : ICarComponent
    {
        private readonly string _name;
        private readonly List<ICarComponent> _components;

        public CarGroup(string name)
        {
            _name = name;
            _components = new List<ICarComponent>();
        }

        public void AddComponent(ICarComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(ICarComponent component)
        {
            _components.Remove(component);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car group: {_name}");
            foreach (var component in _components)
            {
                component.DisplayInfo();
            }
        }
    }


    // mix the Factory, Singleton, and Composite patterns together in your design, depending on your requirements.
    // Combining these patterns can help  create a more maintainable, flexible, and scalable system.
    // class that is responsible for creating instances of CarPart and CarGroup.
    // This ensures that the creation of car components is centralized, making it easier to manage and maintain.
    public class CarComponentFactory
    {
        // Singleton
        private static readonly Lazy<CarComponentFactory> _instance = new(() => new CarComponentFactory());

        // Factory
        public static CarComponentFactory Instance => _instance.Value;

        // Private constructor
        private CarComponentFactory() { }

        // Factory methods
        public ICarComponent CreateCarPart(string name)
        {
            return new CarPart(name);
        }

        // Factory methods 
        public CarGroup CreateCarGroup(string name)
        {
            return new CarGroup(name);
        }
    }

}


