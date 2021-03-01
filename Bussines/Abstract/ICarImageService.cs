using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface ICarImageService 
    {
        IResult Add(IFormFile Entity,CarImage carImage);
        IResult Delete(int id);
        IResult Update(IFormFile Entity, CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetImagesFromSameProperty(CarImage carImage);
    }
}
