using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental Entity);
        IResult Delete(Rental Entity);
        IResult Update(Rental Entity);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
        IDataResult<Rental> GetById(int id);
        IResult HireACar(CardInformations CardInformations);
        IDataResult<List<Rental>> GetRentalsByCarId(int carId);
    }
}
