using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Com.Wiseape.Utility;
using System.Linq.Expressions;

namespace Com.Wiseape.Framework
{
    public interface IBusinessService
    {
        OperationResult FindAll(SelectParam selectParam, int? page, int? size);
        OperationResult FindAllByKeyword(SelectParam selectParam, int? page, int? size);
        OperationResult GetTotal(SelectParam selectParam);
        OperationResult Get(object id);
        OperationResult Add(object o);
        OperationResult Update(object o);
        OperationResult Delete(object o);
    }
}
