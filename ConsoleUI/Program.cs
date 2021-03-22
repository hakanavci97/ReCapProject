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
            foreach (var car in carManager.carDetailDtos())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);

            }
            Console.WriteLine("--------------------------------");

            CarManager carManager_ = new CarManager(new EfCarDal());
            var car_ = carManager_.GetById(2);
            Console.WriteLine(car_.Id+" "+car_.CarName+" "+car_.BrandId+" "+car_.ColorId+" "+car_.DailyPrice+" "+car_.Description);

            //Console.WriteLine("--------------------------------");
            //foreach (var car in carManager.GetCarsByBrandId(6))
            //{
            //    Console.WriteLine(car.Id + " " + car.CarName+" "+ car.BrandId + " " + car.ColorId + " " + car.ModelYear.Year + " " + car.DailyPrice + " " + car.Description);

            //}
            //Console.WriteLine("--------------------------------");

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Id+" "+color.Name);
            //}
            //Console.WriteLine("--------------------------------");
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Id + " " + brand.Name);
            //}



        }
    }
}
