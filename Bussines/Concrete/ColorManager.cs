using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color Entity)
        {
            _colorDal.Add(Entity);
        }

        public void Delete(Color Entity)
        {
            _colorDal.Delete(Entity);
        }

        public List<Color> GelAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.GetById(p=>p.Id==id);
        }

        public void Update(Color Entity)
        {
            _colorDal.Delete(Entity);
        }
    }
}
