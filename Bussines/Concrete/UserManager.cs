using Bussines.Abstract;
using Bussines.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User Entity)
        {
            _userDal.Add(Entity);
            return new SuccesResult($"{Entity.GetType()} Added.");
        }

        public IResult Delete(User Entity)
        {
            _userDal.Delete(Entity);
            return new SuccesResult("User Deleted.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(),"All User Getted.");
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccesDataResult<User>(_userDal.GetById(p => p.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccesDataResult<User>(_userDal.GetById(user => user.Email == email),Messages.UserGet);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User Entity)
        {
            _userDal.Update(Entity);
            return new SuccesResult($"{Entity.GetType()} Updated" );
        }
    }
}
