
/***********************************************************************
* 
* 	File Name: UploadedFileForm.cs
* 	Created Date: 3/22/2017 10:51:19 AM
* 
* **********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;

namespace Com.Wiseape.Gateway.FileManager.View.Form
{
	/*
	* Class Name	: UploadedFileForm
	* Description	: Form Class for UploadedFile module.
	*/
	public class UploadedFileForm : DataForm
	{
	
	
		private Int64 idFile;
		public Int64 IdFile
		{
			set
			{
				idFile = value;
			}
			get
			{
				return idFile;
			}
		}
	
		private String originalFileName;
		public String OriginalFileName
		{
			set
			{
				originalFileName = value;
			}
			get
			{
				return originalFileName;
			}
		}
	
		private String targetFileName;
		public String TargetFileName
		{
			set
			{
				targetFileName = value;
			}
			get
			{
				return targetFileName;
			}
		}
	
		private Int32 fileSize;
		public Int32 FileSize
		{
			set
			{
				fileSize = value;
			}
			get
			{
				return fileSize;
			}
		}
	
		private String fileInfo;
		public String FileInfo
		{
			set
			{
				fileInfo = value;
			}
			get
			{
				return fileInfo;
			}
		}
	
		private DateTime uploadedDate;
		public DateTime UploadedDate
		{
			set
			{
				uploadedDate = value;
			}
			get
			{
				return uploadedDate;
			}
		}
	
		private Int64 userId;
		public Int64 UserId
		{
			set
			{
				userId = value;
			}
			get
			{
				return userId;
			}
		}
	
		/* Constructor */
		public UploadedFileForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

