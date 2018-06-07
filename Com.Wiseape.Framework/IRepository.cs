using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Com.Wiseape.Framework
{
    public interface IRepository
    {
        void Add(object instance);
        object Get(object id);
        void Delete(object id);
        void Update(object instance);
        List<Object> FindAll(SelectParam selectParam, int? page, int? size) ;
        Int64 GetTotal(SelectParam selectParam);
    }
}
