// See https://aka.ms/new-console-template for more information

using Flyweight;
Console.WriteLine("Flyweight");

CarPartPropertiesFactory factory = new CarPartPropertiesFactory();

CarPartProperties redMetalProperties = factory.GetCarPartProperties("Red", "Metal");
CarPartProperties bluePlasticProperties = factory.GetCarPartProperties("Blue", "Plastic");

// sharing common properties across multiple objects help reduce memory footprint
CarPart engine = new CarPart("Engine", redMetalProperties);
CarPart door = new CarPart("Door", redMetalProperties);
CarPart window = new CarPart("Window", bluePlasticProperties);

engine.DisplayInfo(); // Output: Type: Engine, Color: Red, Material: Metal
door.DisplayInfo();   // Output: Type: Door, Color: Red, Material: Metal
window.DisplayInfo(); // Output: Type: Window, Color: Blue, Material: Plastic




//consider a scenario where our car manufacturing company wants to reduce memory consumption when dealing with large numbers of car parts.
//Each car part has a type, a color, and a material. Many car parts have the same color and material,
//so we can use the Flyweight pattern to share common properties between multiple car parts and reduce memory usage.
namespace Flyweight
{

    //create a car part properties class to represent shared car part properties
    public class CarPartProperties
    {
        public string Color { get; }
        public string Material { get; }

        public CarPartProperties(string color, string material)
        {
            Color = color;
            Material = material;
        }
    }

    // create a car parts factory that will managed shared car part properties instances and return them when requested
    public class CarPartPropertiesFactory
    {
        //
        private readonly Dictionary<string, CarPartProperties> _propertiesCache = new();

        public CarPartProperties GetCarPartProperties(string color, string material)
        {

            string key = $"{color}-{material}";
            //cache --  if the key does not exist, create it. otherwise retrieve it
            if (!_propertiesCache.ContainsKey(key))
            {
                _propertiesCache[key] = new CarPartProperties(color, material);
            }

            return _propertiesCache[key];
        }
    }

    //create car part class to represetn other car parts
    public class CarPart
    {
        public string Type { get; }
        public CarPartProperties Properties { get; }

        public CarPart(string type, CarPartProperties properties)
        {
            Type = type;
            Properties = properties;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Type: {Type}, Color: {Properties.Color}, Material: {Properties.Material}");
        }
    }


}
