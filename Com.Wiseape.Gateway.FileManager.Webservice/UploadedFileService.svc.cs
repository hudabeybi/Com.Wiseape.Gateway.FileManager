using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Framework;
using System.Web.Script.Serialization;
using Com.Wiseape.Gateway.FileManager.Data.Model;
using Com.Wiseape.Gateway.FileManager.View.Form;
using Com.Wiseape.Gateway.FileManager.View.Validator;
using Com.Wiseape.Gateway.FileManager.View.FormDataConverter;
using System.Web.Hosting;
using System.IO;
using System.Drawing;

namespace Com.Wiseape.Gateway.FileManager.Webservice
{
    public class UploadedFileService : IUploadedFileService
    {
        class Keywords
        {
            public static string UPLOADEDFILE = "UploadedFile";
        }

        [WebInvoke(Method = "GET",
            UriTemplate = "file/get/{idfile}")]
        public Stream GetImage(string idfile)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>(Keywords.UPLOADEDFILE, ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idfile);
            UploadedFileForm uploadedFileForm = new UploadedFileForm();
            UploadedFileFormDataConverter converter = new UploadedFileFormDataConverter();
            converter.PopulateForm(result.Data, uploadedFileForm);

            FileStream fs = File.OpenRead(Path.Combine(HostingEnvironment.MapPath("~/Resources/Uploads"), uploadedFileForm.TargetFileName));
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return fs;
        }

        [WebInvoke(Method = "GET",
             UriTemplate = "file/getfile/{filename}")]
        public Stream GetUploadedImage(string filename)
        {

            FileStream fs = File.OpenRead(Path.Combine(HostingEnvironment.MapPath("~/Resources/Uploads"), filename));
            //WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return fs;
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "file/delete/{filename}")]
        public string DeleteImage(string filename)
        {
            OperationResult result = new OperationResult();
            result.Result = true;

            try
            {
                File.Delete(Path.Combine(HostingEnvironment.MapPath("~/Resources/Uploads"), filename));
            }
            catch(Exception err)
            {
                result.Result = false;
                result.Data = err;
                result.Message = err.Message;
            }

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "file/delete/{filename}")]
        public string DeleteImagePost(string filename)
        {
            OperationResult result = new OperationResult();
            result.Result = true;

            try
            {
                File.Delete(Path.Combine(HostingEnvironment.MapPath("~/Resources/Uploads"), filename));
            }
            catch (Exception err)
            {
                result.Result = false;
                result.Data = err;
                result.Message = err.Message;
            }

            return Serializer.Json.Serialize(result);
        }


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/upload/{fileName}/{targetfilename}")]
        public string UploadFileWithTarget(string filename, string targetFilename, Stream stream)
        {
            OperationResult result = new OperationResult(true);
            try
            {

                string FilePath = Path.Combine(HostingEnvironment.MapPath("~/Resources/Uploads"), targetFilename);

                int length = 0;
                using (FileStream writer = new FileStream(FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[8192];
                    while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }


                IBusinessService businessService = Factory.Create<IBusinessService>(Keywords.UPLOADEDFILE, ClassType.clsTypeBusinessService);
                object dataObject = Factory.Create<object>(Keywords.UPLOADEDFILE, ClassType.clsTypeDataModel);

                UploadedFileForm formUpload = new UploadedFileForm();
                formUpload.FileSize = length;
                formUpload.OriginalFileName = filename;
                formUpload.TargetFileName = targetFilename;
                formUpload.UserId = 1;
                formUpload.UploadedDate = DateTime.Now;

                UploadedFileFormDataConverter formDataConverter = new UploadedFileFormDataConverter();
                formDataConverter.PopulateData(formUpload, dataObject);

                result = businessService.Add(dataObject);
            }
            catch(Exception err)
            {
                result = new OperationResult(false, err);
            }

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/upload/{fileName}")]
        public string UploadFile(string filename, Stream stream)
        {
            string targetFileName = filename;
            return UploadFileWithTarget(filename, targetFileName, stream);
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "uploadedfile/add")]
        public string AddUploadedFile(UploadedFileForm uploadedFileForm)
        {
            DefaultController defaultController = new DefaultController(UploadedFileService.Keywords.UPLOADEDFILE);
            defaultController.FormValidator = new UploadedFileFormValidator();

            OperationResult result = defaultController.Add(uploadedFileForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "uploadedfile/find/{keyword}/{page}/{size}")]
        public string FindUploadedFileList(string keyword, string page, string size)
        {

            SelectParam selectParam = new SelectParam();
            selectParam.Keyword = keyword;
            if (keyword == "all")
                selectParam.Keyword = null;

            IBusinessService businessService = Factory.Create<IBusinessService>("UploadedFile", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.FindAllByKeyword(selectParam, Convert.ToInt16( page), Convert.ToInt16( size));

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "uploadedfile/get/{idFile}")]
        public string GetUploadedFile(string idFile)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("UploadedFile", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idFile);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "uploadedfile/update")]
        public string UpdateUploadedFile(UploadedFileForm uploadedFileForm)
        {
            DefaultController defaultController = new DefaultController(UploadedFileService.Keywords.UPLOADEDFILE);
            defaultController.FormValidator = new UploadedFileFormValidator();

            OperationResult result = defaultController.Update(uploadedFileForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "uploadedfile/delete/{idFile}")]
        public string DeleteUploadedFile(string idFile)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("UploadedFile", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Delete(idFile);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "uploadedfile/lookups")]
        public string GetLookups()
        {
			Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
		
            OperationResult result = new OperationResult(true, data);
            return Serializer.Json.Serialize(result);
        }
    }
}
