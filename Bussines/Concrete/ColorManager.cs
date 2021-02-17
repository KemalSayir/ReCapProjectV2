using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color Entity)
        {
            _colorDal.Add(Entity);
            return new SuccesResult();
        }

        public IResult Delete(Color Entity)
        {
            _colorDal.Delete(Entity);
            return new SuccesResult();
        }

        public IDataResult<List<Color>> GelAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccesDataResult<Color>(_colorDal.GetById(p=>p.Id==id));
        }

        public IResult Update(Color Entity)
        {
            _colorDal.Delete(Entity);
            return new SuccesResult();
        }
    }
}
