using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.FileManager.Data.Model;
using Com.Wiseape.Gateway.FileManager.Data.Repository;
using Com.Wiseape.Gateway.FileManager.Business.Contracts;
using Com.Wiseape.Utility;
using System.Linq.Expressions;

namespace Com.Wiseape.Gateway.FileManager.Business.Service
{
    public class UploadedFileBusinessService : BaseBusinessService, IUploadedFileBusinessService
    {
        public UploadedFileBusinessService() : base("UploadedFile")
        {
        }

	
		public OperationResult FindAllByOriginalFileName(string originalFileName)
		{
			SelectParam selectParam = new SelectParam("OriginalFileName.Contains(\"" + originalFileName + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByTargetFileName(string targetFileName)
		{
			SelectParam selectParam = new SelectParam("TargetFileName.Contains(\"" + targetFileName + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByFileInfo(string fileInfo)
		{
			SelectParam selectParam = new SelectParam("FileInfo.Contains(\"" + fileInfo + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByUploadedDate(DateTime uploadedDateStart, DateTime uploadedDateEnd)
		{
			string date1 = uploadedDateStart.ToString("yyyy-MM-dd hh:mm:ss");
			string date2 = uploadedDateEnd.ToString("yyyy-MM-dd hh:mm:ss");
			string where = "(UploadedDate >= Convert.ToDateTime(\"" + date1 + "\") && ";
			where += "UploadedDate <= Convert.ToDateTime(\"" + date2 + "\") )";

			SelectParam selectParam = new SelectParam(where);
            return this.FindAll(selectParam, null, null);
		}
	

        protected override string GetPredicateByKeyword(string keyword)
        {
            string where = "";
	
			where += "OriginalFileName.Contains(\"" + keyword + "\") || ";
	
			where += "TargetFileName.Contains(\"" + keyword + "\") || ";
	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

    }
}
