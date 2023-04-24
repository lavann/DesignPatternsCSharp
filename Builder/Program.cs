using Builder;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Builder");

// Create a car builder.
ICarBuilder builder = new CarBuilder();
Car car = builder.SetColor("Red")
                  .SetEngine("V8")
                  .SetTransmission("Automatic")
                  .AddSunroof()
                  .AddGPS()
                  .Build();
Console.WriteLine(car.ToString());
Console.ReadLine();


//consider  car manufacturing company produces cars with various features,
//such as different colors, transmissions, engines, and optional extras like sunroofs and GPS systems.
//We can use the Builder pattern to create cars with different combinations of these features
namespace Builder
{
    public class Car
    {
        public string Color { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public bool HasSunroof { get; set; }
        public bool HasGPS { get; set; }

        public override string ToString()
        {
            return $"Color: {Color}, Engine: {Engine}, Transmission: {Transmission}, Sunroof: {HasSunroof}, GPS: {HasGPS}";
        }
    }

    public interface ICarBuilder
    {
        ICarBuilder SetColor(string color);
        ICarBuilder SetEngine(string engine);
        ICarBuilder SetTransmission(string transmission);
        ICarBuilder AddSunroof();
        ICarBuilder AddGPS();
        Car Build();
    }

    public class CarBuilder : ICarBuilder
    {
        private Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public ICarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public ICarBuilder SetTransmission(string transmission)
        {
            _car.Transmission = transmission;
            return this;
        }

        public ICarBuilder AddSunroof()
        {
            _car.HasSunroof = true;
            return this;
        }

        public ICarBuilder AddGPS()
        {
            _car.HasGPS = true;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }

}