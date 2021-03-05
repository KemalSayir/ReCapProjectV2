using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService 
    {
        IResult Add(Color Entity);
        IResult Delete(Color Entity);
        IResult Update(Color Entity);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
    }
}
