using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("cars.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccesResult("Araba Eklendi !");

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Car>>("Sistem Bakımda");
            }
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(), "Başarıyla Getirildi");
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.GetById(p => p.Id == id);
            if (result == null)
                return new ErrorDataResult<Car>("Belirtilen id ye sahip ürün bulunamadı.");
            return new SuccesDataResult<Car>(_carDal.GetById(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImageDetails()
        {
            return new SuccesDataResult<List<CarImageDetailDto>>(CheckIfCarImagesNull(_carDal.GetCarImageDetails()));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImageDetailByCarId(int carId)
        {
            return new SuccesDataResult<List<CarImageDetailDto>>(CheckIfCarImagesNull(_carDal.GetCarImagesDetailByCarId(carId)));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImageDetailByColorId(int colorId)
        {
            return new SuccesDataResult<List<CarImageDetailDto>>(CheckIfCarImagesNull(_carDal.GetCarImagesDetailByColorId(colorId)));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImageDetailByBrandId(int brandId)
        {
            return new SuccesDataResult<List<CarImageDetailDto>>(CheckIfCarImagesNull(_carDal.GetCarImagesDetailByBrandId(brandId)));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetCarImageDetailByColorIdAndBrandId(int colorId,int brandId)
        {
            return new SuccesDataResult<List<CarImageDetailDto>>(CheckIfCarImagesNull(_carDal.GetCarImagesDetailByColorIdAndBrandId(colorId,brandId)));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult();
        }
        
        private List<CarImageDetailDto> CheckIfCarImagesNull(List<CarImageDetailDto> result)
        {
            foreach (var carImagesDetail in result)
            {
                if (carImagesDetail.CarImages.Count == 0)
                {
                    carImagesDetail.CarImages.Add(new CarImage { ImagePath = @"/Images/Soru_isareti.jpg" });
                }
            }
            return result;
        }

    }
}
