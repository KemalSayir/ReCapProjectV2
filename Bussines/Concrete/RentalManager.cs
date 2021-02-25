using Bussines.Abstract;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental Entity)
        {
            _rentalDal.Add(Entity);
            return new SuccesResult($"{Entity.GetType()} Added.");
        }

        public IResult Delete(Rental Entity)
        {
            _rentalDal.Delete(Entity);
            return new SuccesResult($"{Entity.GetType()} Deleted.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(),"Rentals Listed");
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.GetById(p=>p.Id == id));
        }

        public IResult Update(Rental Entity)
        {
            _rentalDal.Update(Entity);
            return new SuccesResult($"{Entity.GetType()}");
                
                
        }
    }
}
