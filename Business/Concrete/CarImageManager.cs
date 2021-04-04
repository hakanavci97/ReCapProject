using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal=carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if(result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.FileAdd(formFile);
            carImage.CreatedDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(FileHelper.FileDelete(carImage.ImagePath));
            if(result!=null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();


        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            string path = @"\Images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if(!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = carId, ImagePath = path, CreatedDate = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.CarImagesListed);
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +_carImageDal.Get(c => c.Id == carImage.Id & c.CarId==carImage.CarId).ImagePath;
            carImage.ImagePath = FileHelper.FileUpdate(oldPath, formFile);
            carImage.CreatedDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if(result>=5)
            {
                return new  ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();

        }

    }
}
