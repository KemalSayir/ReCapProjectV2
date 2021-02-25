using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceRepository<T> 
        where T : class, IEntity,new()
    {
        IResult Add(T Entity);
        IResult Delete(T Entity);
        IResult Update(T Entity);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}
