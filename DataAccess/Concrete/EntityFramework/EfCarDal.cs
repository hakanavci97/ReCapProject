using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                             join cr in context.Colors
                             on c.ColorId equals cr.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarName = c.CarName, BrandName = b.Name, ColorName = cr.Name, DailyPrice = c.DailyPrice
                             };

                   return result.ToList();
            }


            //var result = from p in context.Products
            //             join c in context.Categories
            //             on p.CategoryId equals c.CategoryId
            //             select new ProductDetailDto
            //             {
            //                 ProductId = p.ProductId,
            //                 ProductName = p.ProductName,
            //                 CategoryName = c.CategoryName,
            //                 UnitsInStock = p.UnitsInStock

            //             };
            //return result.ToList();
        }
    }
}
