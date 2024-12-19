using Database_funksjonstest;
using Microsoft.Data.SqlClient;


UserInterface userInterface = new UserInterface();
Cars cars = new Cars();
cars.GetCars();
while (true)
{
    userInterface.MainMenu(cars);
}