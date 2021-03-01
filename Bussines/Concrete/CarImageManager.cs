using Bussines.Abstract;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile Entity, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage));
            if (!result.Succes)
            {
                return new ErrorResult(result.Message);
            }
            var path = FileHelper.WriteFile(Entity);
            _carImageDal.Add(new CarImage
            {
                CarId = carImage.CarId,
                ImagePath = path.Result,
                Date = DateTime.Now
            });
            return new SuccesResult("Image Added!");
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(int id)
        {
            var carImage = _carImageDal.GetById(p => p.Id == id);
            FileHelper.DeleteFile(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult("Image Deleted!");
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.GetById(p => p.Id == id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesFromSameProperty(CarImage carImage)
        {
            return new SuccesDataResult<List<CarImage>>(CheckIfCarImagesNullOrExist(carImage));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile Entity, CarImage carImage)
        {
            var carimage = _carImageDal.GetById(p => p.CarId == carImage.CarId);
            FileHelper.DeleteFile(carimage.ImagePath);
            carImage.ImagePath = FileHelper.WriteFile(Entity).Result;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carimage);
            return new SuccesResult("Image Updated!");
        }

        // Bussiness rules
        private IResult CheckImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(p=>p.CarId == carImage.CarId).Count;
            if (result < 6)
            {
                return new ErrorResult(Messages.ImageLimit);
            }
            return new SuccesResult();
        }

        private List<CarImage> CheckIfCarImagesNullOrExist(CarImage carImage)
        {
            string path = @"C:\Users\Bilal\source\repos\ReCapProjectV2\WebAPI\Images\Soru_isareti.jpg";
            var result = _carImageDal.GetAll(p => p.CarId == carImage.CarId);
            if (result.Count == 0)
            {
                return new List<CarImage>() { new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now} };
            }
            return result;
        }

    }
}
