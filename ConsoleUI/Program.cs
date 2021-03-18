using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+" "+car.CarName+" "+car.BrandId+" "+car.ColorId+" "+car.ModelYear.Year +" "+car.DailyPrice+" "+car.Description);

            }
            Console.WriteLine("--------------------------------");
            foreach (var car in carManager.GetCarsByBrandId(6))
            {
                Console.WriteLine(car.Id + " " + car.CarName+" "+ car.BrandId + " " + car.ColorId + " " + car.ModelYear.Year + " " + car.DailyPrice + " " + car.Description);

            }
            Console.WriteLine("--------------------------------");
           
          

        }
    }
}
