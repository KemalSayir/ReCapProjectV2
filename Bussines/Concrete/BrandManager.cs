using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand Entity)
        {
            if (Entity.Name.Length > 2)
            {
               _brandDal.Add(Entity);
            }
            else
            {
                Console.WriteLine("Girdiğiniz İsim 2 karakterden küçük olmamalıdır");
            }
        }

        public void Delete(Brand Entity)
        {
            _brandDal.Delete(Entity);
        }

        public List<Brand> GelAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(p => p.Id == id);
        }

        public void Update(Brand Entity)
        {
            _brandDal.Update(Entity);
        }
    }
}
