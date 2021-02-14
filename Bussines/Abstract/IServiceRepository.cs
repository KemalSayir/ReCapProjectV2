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
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
        List<T> GelAll();
        T GetById(int id);
    }
}
