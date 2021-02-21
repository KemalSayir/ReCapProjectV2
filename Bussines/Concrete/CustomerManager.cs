using Bussines.Abstract;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer Entity)
        {
            _customerDal.Add(Entity);
            return new SuccesResult($"{Entity.GetType()} Added.");
        }

        public IResult Delete(Customer Entity)
        {
            _customerDal.Delete(Entity);
            return new SuccesResult($"{Entity.GetType()} Deleted.");
        }

        public IDataResult<List<Customer>> GelAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(),$"Customers Listed!");
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccesDataResult<Customer>(_customerDal.GetById(p=>p.UserId == id));
        }

        public IResult Update(Customer Entity)
        {
            _customerDal.Update(Entity);
            return new SuccesResult($"{Entity.GetType()} Updated.");
        }
    }
}
