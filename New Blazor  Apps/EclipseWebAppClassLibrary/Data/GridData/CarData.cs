using EclipseWebAppClassLibrary.Data.Interfaces;

namespace EclipseWebAppClassLibrary.Data.GridData;

public class CarData : ICarData
{
    public List<Car> GetCarList()
    {
        var r = new Random();
        var CarList = new List<Car>();

        CarList.Add(new Car
        {
            VinNumber = r.Next(10000, 43433),
            Make = "Nissan",
            Model = "Altima",
            Price = new decimal(r.Next(5000, 10000))
        });

        CarList.Add(new Car
        {
            VinNumber = r.Next(10000, 43433),
            Make = "Honda",
            Model = "Civic",
            Price = new decimal(r.Next(5000, 10000))
        });

        CarList.Add(new Car
        {
            VinNumber = r.Next(10000, 43433),
            Make = "Ford",
            Model = "Focus",
            Price = new decimal(r.Next(5000, 10000))
        });

        return CarList;
    }
}