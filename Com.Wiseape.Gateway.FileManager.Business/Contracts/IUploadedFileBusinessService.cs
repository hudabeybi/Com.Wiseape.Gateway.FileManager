using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.FileManager.Data.Model;

namespace Com.Wiseape.Gateway.FileManager.Business.Contracts
{
    public interface IUploadedFileBusinessService
    {
	
		OperationResult FindAllByOriginalFileName(string originalFileName);
	
		OperationResult FindAllByTargetFileName(string targetFileName);
	
		OperationResult FindAllByFileInfo(string fileInfo);
	
		OperationResult FindAllByUploadedDate(DateTime uploadedDateStart, DateTime uploadedDateEnd);
	
    }
}
