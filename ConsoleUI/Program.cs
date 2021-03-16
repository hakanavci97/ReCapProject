using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+" "+car.BrandId+" "+car.ColorId+" "+car.ModelYear.Year +" "+car.DailyPrice+" "+car.Description);

            }
            Console.WriteLine("--------------------------------");
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear.Year + " " + car.DailyPrice + " " + car.Description);

            }
            Console.WriteLine("--------------------------------");
           
          

        }
    }
}
