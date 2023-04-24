// See https://aka.ms/new-console-template for more information

using Proxy;
Console.WriteLine("Proxy");
ICarDiagnosticSystem technicianProxy = new CarDiagnosticSystemProxy("Technician");
ICarDiagnosticSystem engineerProxy = new CarDiagnosticSystemProxy("Engineer");
ICarDiagnosticSystem customerProxy = new CarDiagnosticSystemProxy("Customer");

technicianProxy.ReadErrorCodes(); // Output: Reading error codes...
technicianProxy.CheckSensorData(); // Output: Checking sensor data...

engineerProxy.ReadErrorCodes(); // Output: Access denied: insufficient privileges
engineerProxy.CheckSensorData(); // Output: Checking sensor data...

customerProxy.ReadErrorCodes(); // Output: Access denied: insufficient privileges
customerProxy.CheckSensorData(); // Output: Access denied: insufficient privileges





/*
 * consider a scenario where our car manufacturing company wants to control access to the car diagnostic system. 
 * The car diagnostic system allows us to read error codes, check sensor data, and perform other diagnostic tasks. 
 * We can use the Proxy pattern to restrict access to the diagnostic system based on user roles.
 * */

namespace Proxy
{
    //define the ICarDiagnosticSystem interface, which represents the diagnostic system's functionality
    public interface ICarDiagnosticSystem
    {
        void ReadErrorCodes();
        void CheckSensorData();
    }

    //create the CarDiagnosticSystem class, which implements the ICarDiagnosticSystem interface:#
    public class CarDiagnosticSystem : ICarDiagnosticSystem
    {
        public void ReadErrorCodes()
        {
            Console.WriteLine("Reading error codes...");
        }

        public void CheckSensorData()
        {
            Console.WriteLine("Checking sensor data...");
        }
    }

    //Create the CarDiagnosticSystemProxy class, which will control access to the CarDiagnosticSystem based on user roles
    public class CarDiagnosticSystemProxy : ICarDiagnosticSystem
    {
        private readonly CarDiagnosticSystem _carDiagnosticSystem;
        private readonly string _userRole;

        public CarDiagnosticSystemProxy(string userRole)
        {
            _carDiagnosticSystem = new CarDiagnosticSystem();
            _userRole = userRole;
        }

        public void ReadErrorCodes()
        {
            if (_userRole == "Technician")
            {
                _carDiagnosticSystem.ReadErrorCodes();
            }
            else
            {
                Console.WriteLine("Access denied: insufficient privileges");
            }
        }

        public void CheckSensorData()
        {
            if (_userRole == "Technician" || _userRole == "Engineer")
            {
                _carDiagnosticSystem.CheckSensorData();
            }
            else
            {
                Console.WriteLine("Access denied: insufficient privileges");
            }
        }
    }



}