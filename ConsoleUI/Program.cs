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

          
            

            Rental rental = new Rental();
            rental.Id = 7;
            rental.CarId = 4;
            rental.CustomerId = 1;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = DateTime.Now.AddDays(5);



            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentalAdded = rentalManager.Add(rental);
            Console.WriteLine(rentalAdded.Message);

           
            






           
            



        }
    }
}
