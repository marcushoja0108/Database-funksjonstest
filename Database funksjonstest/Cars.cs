using Dapper;
using Microsoft.Data.SqlClient;

namespace Database_funksjonstest
{
    internal class Cars
    {
        public List<Car> _cars;
        public string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Car register\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public Cars()
        {
            _cars = new List<Car>();
        }

        public void GetCars()
        {
            var sql = "SELECT * FROM Register";
            var conn = new SqlConnection(connStr);
            var cars = conn.Query<Car>(sql);
            _cars = cars.ToList();
        }

        public void ShowAllCars()
        {
            GetCars();
            if(_cars == null)
            {
                Console.WriteLine("What list?");
            }
            else if(_cars.Count < 1)
            {
                Console.WriteLine("No cars in the list");
            }
            else
            {
                foreach (var car in _cars)
                {
                    car.ShowCarInfo();
                }
            }
        }

        public Car GetCarByRegNumber(int prodNumber)
        {
            Car result = _cars.FirstOrDefault(car => car.ProdNumber == prodNumber);
            return result;
        }

    }
}
