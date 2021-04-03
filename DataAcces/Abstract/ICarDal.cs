using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarImageDetailDto> GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null);
        List<CarImageDetailDto> GetCarImagesDetailByCarId(int carId);
        List<CarImageDetailDto> GetCarImagesDetailByColorId(int colorId);
        List<CarImageDetailDto> GetCarImagesDetailByBrandId(int brandId);
        List<CarImageDetailDto> GetCarImagesDetailByColorIdAndBrandId(int colorId, int brandId);
    }
}
