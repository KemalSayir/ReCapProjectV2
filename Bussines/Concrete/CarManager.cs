using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccesResult("Araba Eklendi !");
            }
            else
                return new ErrorResult("Girdiğiniz arabanın günlük fiyatı 0 dan küçük olmamalıdır"); 
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult();
        }

        public IDataResult<List<Car>> GelAll()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<Car>>("Sistem Bakımda");
            }
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),"Başarıyla Getirildi");
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.GetById(p=>p.Id == id);
            if (result == null)
                return new ErrorDataResult<Car>("Belirtilen id ye sahip ürün bulunamadı.");
            return new SuccesDataResult<Car>(_carDal.GetById(p=>p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult();
        }
    }
}
