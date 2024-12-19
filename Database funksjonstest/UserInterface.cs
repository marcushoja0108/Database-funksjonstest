using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_funksjonstest
{
    internal class UserInterface
    {
        public void MainMenu(Cars cars)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the main car registry");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1. View registered cars");
            Console.WriteLine("2. Register new car");
            Console.WriteLine("3. Update existing car");
            switch (Console.ReadLine())
            {
                case "1":
                    ViewRegisteredCars(cars);
                    break;
                case "2":
                    RegisterNewCarMenu(cars);
                break;
                case "3":
                    EditExistingCar(cars);
                    break;
                default:
                Console.WriteLine("Invalid command");
                break;
            }
        }

        public void ViewRegisteredCars(Cars cars)
        {
            cars.ShowAllCars();
        }

        public void RegisterNewCarMenu(Cars cars)
        {
            Console.Write("Production Number: ");
            var newProdNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("RegNumber:  ");
            var newRegNumber = Console.ReadLine();
            Console.Write("Brand:  ");
            var newBrand = Console.ReadLine();
            Console.Write("Model:  ");
            var newModel = Console.ReadLine();
            Console.Write("Model Year:  ");
            var newModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Color:  ");
            var newColor = Console.ReadLine();
            Console.Write("Km:  ");
            var newKm = Convert.ToInt32(Console.ReadLine());
            Car newCar = new Car(newProdNumber, newBrand, newModel, newModelYear, newColor, newKm, newRegNumber);
            
            newCar.RegisterNewCar(newCar);
        }

        public void EditExistingCar(Cars cars)
        {
            Console.WriteLine();
            Console.WriteLine("Type the production number of the car you want to edit");
            int prodNumber = Convert.ToInt32(Console.ReadLine());
            Car result = cars.GetCarByRegNumber(prodNumber);
            if (result == null)
            {
                Console.WriteLine("No car with that regNumber found");
            }
            else
            {
                result.EditProperties(prodNumber);
            }
        }
    }
}
