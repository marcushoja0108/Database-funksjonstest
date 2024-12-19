using Dapper;
using Microsoft.Data.SqlClient;

namespace Database_funksjonstest
{
    internal class Car
    {
        public string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Car register\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public int ProdNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int ModelYear { get; private set; }
        public string Color { get; private set; }
        public int KmRange { get; private set; }
        public string RegNumber {  get; private set; }

        public Car(int prodNumber, string brand, string model, int modelYear, string color, int kmRange, string regNumber)
        {
            ProdNumber = prodNumber;
            Brand = brand;
            Model = model;
            ModelYear = modelYear;
            Color = color;
            KmRange = kmRange;
            RegNumber = regNumber;
        }

        public void ShowCarInfo()
        {
            Console.WriteLine("Car Details:");
            Console.WriteLine("------------");
            Console.WriteLine($"Reg: {RegNumber}, Brand: {Brand}, Model: {Model}, " +
           $"Year: {ModelYear}, Color: {Color}, Km: {KmRange}, Prod number: {ProdNumber}");
        }

        public void RegisterNewCar(Car newCar)
        {
            var sql = @"INSERT INTO Register 
                (ProdNumber, Brand, Model, ModelYear, Color, KmRange, RegNumber)
                VALUES (@ProdNumber, @Brand, @Model, @ModelYear, @Color, @KmRange, @RegNumber)";
            var conn = new SqlConnection(connStr);
            var rowsAffected = conn.Execute(sql, newCar);
            Thread.Sleep(700);
            Console.WriteLine($"{newCar.RegNumber} has been registered");
        }

        public void EditProperties(int prodNumber)
        {
            Console.Write($"Production number: {ProdNumber}     New production number: ");
            int newProductionNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Brand: {Brand}                      New brand: ");
            string newBrand = Console.ReadLine();
            Console.Write($"Model: {Model}                      New  model: ");
            string newModel = Console.ReadLine();
            Console.Write($"Model year: {ModelYear}             New model year: ");
            int newModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Color: {Color}                      New color: ");
            string newColor = Console.ReadLine();
            Console.Write($"Km range: {KmRange}                 New km range: ");
            int newKmRange = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Reg number: {RegNumber}             New reg number: ");
            string newRegNumber = Console.ReadLine();
            Console.WriteLine("Commit changes?");
            Console.WriteLine("1. Yes   2. No");
            switch (Console.ReadLine())
            {
                case "1":
                    UpdateCar(prodNumber, newProductionNumber, newBrand, newModel, newModelYear, newColor, newKmRange, newRegNumber);
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Not a valid command");
                    break;
            }
        }

        public void UpdateCar(int prodNumber, int newProductionNumber, string newBrand, string newModel, int newModelYear, string newColor, int newKmRange, string newRegNumber)
        {
            var sql = @"UPDATE Register
                SET ProdNumber = @newProductionNumber, Brand = @newBrand, Model = @newModel, ModelYear = @newModelYear, Color = @newColor, KmRange = @newKmRange, RegNumber = @newRegNumber
                WHERE ProdNumber == @prodNumber";
            var conn = new SqlConnection(connStr);
            var rowsAffected = conn.Execute(sql);
            Console.WriteLine("Car updated!");
        }


    }
}
