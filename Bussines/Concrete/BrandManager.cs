using Business.Abstract;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand Entity)
        {
               _brandDal.Add(Entity);
                return new SuccesResult("Marka Eklendi");
        }

        public IResult Delete(Brand Entity)
        {
            _brandDal.Delete(Entity);
            return new SuccesResult("Marka Başarıyla Silnidi!");
        }

        public IDataResult<List<Brand>> GetAll()
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
