using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);
            Console.WriteLine("--------------------------------");
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);

            }
           

            Console.WriteLine("--------------------------------");
            CarManager carManager_ = new CarManager(new EfCarDal());
            var car_ = carManager_.GetById(2);
            Console.WriteLine(car_.Message);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(car_.Data.Id+" "+ car_.Data.CarName +" "+ car_.Data.BrandId +" "+ car_.Data.ColorId +" "+ car_.Data.DailyPrice +" "+ car_.Data.Description);

            //Car car1 = new Car();
            //car1.Id = 11;
            //car1.CarName = "Accent";
            //car1.ColorId = 4;
            //car1.ModelYear = DateTime.Now;
            //car1.DailyPrice = 197.5m;
            //car1.Description = "Yeni Araç";
            //Console.WriteLine("--------------------------------");
            //CarManager carManagerAdded = new CarManager(new EfCarDal());
            //var resultAdded= carManagerAdded.Add(car1);
            //Console.WriteLine(resultAdded.Message);
            //Console.WriteLine("--------------------------------");

            Rental rental = new Rental();
            rental.Id = 6;
            rental.CarId = 4;
            rental.CustomerId = 1;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = DateTime.Now.AddDays(5);



            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentalAdded = rentalManager.Add(rental);
            Console.WriteLine(rentalAdded.Message);

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result1 = rentalManager.GetByRentalCarId(4);
            //foreach (var results2 in result1.Data)
            //{
            //    Console.WriteLine(results2.RentDate);
            //}






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
