using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=new DateTime(2020,02,21),DailyPrice=250,Description="Otomatik Vites"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=new DateTime(2019,02,21),DailyPrice=240,Description="Manuel Vites"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=new DateTime(2018,02,21),DailyPrice=220,Description="Hasar Kayıtlı"},
                new Car{Id=4,BrandId=4,ColorId=4,ModelYear=new DateTime(2017,02,21),DailyPrice=210,Description="Çelik Jant"}

            };

        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }

}