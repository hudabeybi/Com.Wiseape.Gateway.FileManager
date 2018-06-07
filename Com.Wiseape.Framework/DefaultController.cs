using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Utility;

namespace Com.Wiseape.Framework
{
    public class DefaultController
    {
        private IBusinessService businessService;
        public IBusinessService BusinessService
        {
            get
            {
                return businessService;
            }
        }

        private IFormValidator formValidator;
        public IFormValidator FormValidator
        {
            get
            {
                return formValidator;
            }
            set
            {
                formValidator = value;
            }
        }

        private IFormDataConverter formDataConverter;
        public IFormDataConverter FormDataConverter
        {
            get
            {
                return formDataConverter;
            }
        }

        public String Key { get; set; }
        public DefaultController(string key)
        {
            this.Key = key;
        }


        public OperationResult Add(DataForm formObject)
        {
            OperationResult result = new OperationResult(true, formObject);

            //formValidator = Factory.Create<IFormValidator>(this.Key, ClassType.clsTypeFormValidator);
            ValidationResult validationResult = formValidator.Validate(formObject);
            if (validationResult.Result)
            {
                formDataConverter = Factory.Create<IFormDataConverter>(this.Key, ClassType.clsTypeFormProcessor);
                Object o = Factory.Create<Object>(this.Key, ClassType.clsTypeDataModel);
                formDataConverter.PopulateData(formObject, o);

                businessService = Factory.Create<IBusinessService>(this.Key, ClassType.clsTypeBusinessService);
                result = businessService.Add(o);
            }
            else
            {
                result.Result = false;
                result.Message = "Validation Error";
                result.Data = validationResult;
            }
            return result;
        }

        public OperationResult Update(DataForm formObject)
        {
            OperationResult result = new OperationResult(true, formObject);

            //formValidator = Factory.Create<IFormValidator>(this.Key, ClassType.clsTypeFormValidator);
            ValidationResult validationResult = formValidator.Validate(formObject);
            if (validationResult.Result)
            {
                Object o = Factory.Create<Object>(this.Key, ClassType.clsTypeDataModel);
                System.Reflection.PropertyInfo propertyInfo =  Wiseape.Utility.Assembly.GetKeyProperty(o.GetType());
                object id = formObject.GetType().GetProperty(propertyInfo.Name).GetValue(formObject, null);

                businessService = Factory.Create<IBusinessService>(this.Key, ClassType.clsTypeBusinessService);
                OperationResult res = businessService.Get(id);
                o = res.Data;

                formDataConverter = Factory.Create<IFormDataConverter>(this.Key, ClassType.clsTypeFormProcessor);
                formDataConverter.PopulateData(formObject, o);

                result = businessService.Update(o);
            }
            else
            {
                result.Result = false;
                result.Message = "Validation Error";
                result.Data = validationResult;
            }
            return result;
        }

        public OperationResult Delete(object id)
        {
            OperationResult result = new OperationResult(true, id);

            IBusinessService businessService = Factory.Create<IBusinessService>(this.Key, ClassType.clsTypeBusinessService);
            result = businessService.Delete(id);
            return result;
        }
    }
}
