using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(Brand Entity)
        {
            if (Entity.Name.Length > 2)
            {
               _brandDal.Add(Entity);
                return new SuccesResult("Marka Eklendi");
            }
            else
            {
                return new ErrorResult("Marka Eklenemedi\nGirdiğiniz İsim 2 karakterden küçük olmamalıdır");
            }
        }

        public IResult Delete(Brand Entity)
        {
            _brandDal.Delete(Entity);
            return new SuccesResult("Marka Başarıyla Silnidi!");
        }

        public IDataResult<List<Brand>> GelAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccesDataResult<Brand>(_brandDal.GetById(p => p.Id == id));
        }

        public IResult Update(Brand Entity)
        {
            _brandDal.Update(Entity);
            return new SuccesResult("Marka Başarıyla Güncellendi!");
        }
    }
}
