using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Wiseape.Framework
{
    public class BaseValidator : IFormValidator
    {
        public virtual ValidationResult Validate(DataForm dataForm)
        {
            return new ValidationResult(true);
        }
    }
}
