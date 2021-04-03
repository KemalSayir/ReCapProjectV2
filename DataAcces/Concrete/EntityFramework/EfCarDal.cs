using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              select new CarDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice
                              };
                return result2.ToList();
            }
        }

        // i wrote there bcs: this is about Car not about CarImage .
        public List<CarImageDetailDto> GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              select new CarImageDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear,
                                  CarImages = (from img in context.CarImages
                                               where c.Id == img.CarId
                                               select new CarImage { Id = img.Id, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath} ).ToList() 
                              };
                
                return filter == null ? result2.ToList() : result2.Where(filter).ToList();
            }
        }
        public List<CarImageDetailDto> GetCarImagesDetailByCarId(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              where(c.Id == carId)
                              select new CarImageDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear,
                                  CarImages = (from img in context.CarImages
                                               where c.Id == img.CarId
                                               select new CarImage { Id = img.Id, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath }).ToList()
                              };

                return result2.ToList();
            }
        }
        public List<CarImageDetailDto> GetCarImagesDetailByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              where (c.ColorId == colorId)
                              select new CarImageDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear,
                                  CarImages = (from img in context.CarImages
                                               where c.Id == img.CarId
                                               select new CarImage { Id = img.Id, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath }).ToList()
                              };

                return result2.ToList();
            }
        }
        public List<CarImageDetailDto> GetCarImagesDetailByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              where (c.BrandId == brandId)
                              select new CarImageDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear,
                                  CarImages = (from img in context.CarImages
                                               where c.Id == img.CarId
                                               select new CarImage { Id = img.Id, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath }).ToList()
                              };

                return result2.ToList();
            }
        }
        public List<CarImageDetailDto> GetCarImagesDetailByColorIdAndBrandId(int colorId,int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              where (c.ColorId == colorId)
                              where (c.BrandId == brandId)
                              select new CarImageDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.Name,
                                  CarName = c.Name,
                                  ColorName = co.Name,
                                  DailyPrice = c.DailyPrice,
                                  Description = c.Description,
                                  ModelYear = c.ModelYear,
                                  CarImages = (from img in context.CarImages
                                               where c.Id == img.CarId
                                               select new CarImage { Id = img.Id, CarId = c.Id, Date = img.Date, ImagePath = img.ImagePath }).ToList()
                              };

                return result2.ToList();
            }
        }
    }
}
