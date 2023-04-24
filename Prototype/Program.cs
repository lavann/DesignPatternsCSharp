// See https://aka.ms/new-console-template for more information
using Prototype;

Console.WriteLine("Prototype!");
// Create a base car object
Car baseCar = new Car("Sedan", "Blue", "V6");

// Clone the base car object and modify the color
ICarPrototype redCar = baseCar.Clone();
redCar.Color = "Red";

// Clone the base car object and modify the engine
ICarPrototype electricCar = baseCar.Clone();
electricCar.Engine = "Electric";

Console.WriteLine(baseCar.GetDetails()); // Output: Model: Sedan, Color: Blue, Engine: V6
Console.WriteLine(redCar.GetDetails());  // Output: Model: Sedan, Color: Red, Engine: V6
Console.WriteLine(electricCar.GetDetails()); // Output: Model: Sedan, Color: Blue, Engine: Electric

Console.ReadLine();


//consider a car manufacturing company wants to create new car models based on existing ones with some modifications.
//We can use the Prototype pattern to clone existing car objects and make changes as needed
namespace Prototype
{
    public interface ICarPrototype
    {
        ICarPrototype Clone();
        string GetDetails();
        // without the properties the clone will fail as it will not contain a definition of the properties
        string Color { get; set; }
        string Engine { get; set; } //
    }

    public class Car : ICarPrototype
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }

        public Car(string model, string color, string engine)
        {
            Model = model;
            Color = color;
            Engine = engine;
        }

        public ICarPrototype Clone()
        {
            // MemberwiseClone() creates a shallow copy of the current object.
            //create a new object with the same properties as the current object
            //as the property only has strings which are immutable it is a shallow copy and a new instance is returned
            //if the car had any reference properties and needed to be distinct from the parent object, a deep clone would be required
            return (ICarPrototype)MemberwiseClone();
        }

        public string GetDetails()
        {
            return $"Model: {Model}, Color: {Color}, Engine: {Engine}";
        }
    }


}