using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.FileManager.View.Form;

namespace Com.Wiseape.Gateway.FileManager.View.Validator
{
    public class UploadedFileFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            UploadedFileForm uploadedFileForm = (UploadedFileForm)form;
	
            if(uploadedFileForm.OriginalFileName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Original File Name can not be empty";
            }
	
            if(uploadedFileForm.TargetFileName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Target File Name can not be empty";
            }
	
            return result;
        }
    }
}
