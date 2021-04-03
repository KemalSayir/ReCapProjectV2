using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carDal;

        public InMemoryCarDal()
        {
            _carDal = new List<Car>() { };
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _carDal;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _carDal.SingleOrDefault(p => p.Id == id);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarImageDetailDto> GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarImageDetailDto> GetCarImagesDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarImageDetailDto> GetCarImagesDetailByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarImageDetailDto> GetCarImagesDetailByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarImageDetailDto> GetCarImagesDetailByColorIdAndBrandId(int colorId, int brandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var car1 = _carDal.SingleOrDefault(p => p.Id == car.Id);
            car1.ModelYear = car.ModelYear;
            car1.DailyPrice = car.DailyPrice;
            car1.BrandId = car.BrandId;
            car1.ColorId = car.ColorId;
            car1.Description = car.Description;
        }
    }
}
