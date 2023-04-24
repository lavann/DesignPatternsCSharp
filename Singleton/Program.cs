using Singleton;

//consume the singleton class
CarRegistry carRegistry = CarRegistry.Instance;
string carRegistrationNumber = carRegistry.GenerateRegistrationNumber();

Console.WriteLine(carRegistrationNumber);

Console.ReadLine();

//CarRegistry that manages the registration numbers for all cars in a system.
//We want to ensure that there's only one instance of the CarRegistry to prevent inconsistencies in registration numbers

namespace Singleton
{

    public class CarRegistry
    {
        // Declare a static variable to hold the single instance of CarRegistry.
        private static CarRegistry _instance;

        // Make the constructor private to prevent external instantiation.
        private CarRegistry()
        {
            // Initialize the registry with some data or perform other setup tasks.
        }

        // Provide a public method to access the single instance of CarRegistry.
        public static CarRegistry Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CarRegistry();
                }

                return _instance;
            }
        }

        // Example method to generate a unique registration number for a car.
        public string GenerateRegistrationNumber()
        {
            // Generate a unique registration number for a car and return it.
            return Guid.NewGuid().ToString();
        }
    }
}




