using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {
    }
}
