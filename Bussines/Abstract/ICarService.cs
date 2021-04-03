using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car Entity);
        IResult Delete(Car Entity);
        IResult Update(Car Entity);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarImageDetailDto>> GetCarImageDetails();
        IDataResult<List<CarImageDetailDto>> GetCarImageDetailByCarId(int carId);
        IDataResult<List<CarImageDetailDto>> GetCarImageDetailByColorId(int colorId);
        IDataResult<List<CarImageDetailDto>> GetCarImageDetailByBrandId(int brandId);
        IDataResult<List<CarImageDetailDto>> GetCarImageDetailByColorIdAndBrandId(int colorId, int brandId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);

    }
}
