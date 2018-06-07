using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.FileManager.Data.Model;
using Com.Wiseape.Gateway.FileManager.View.Form;
using System.IO;

namespace Com.Wiseape.Gateway.FileManager.Webservice
{
    [ServiceContract]
    public interface IUploadedFileService
    {
        [OperationContract]
        string UploadFileWithTarget(string filename, string targetFilename, Stream stream);

        [OperationContract]
        string UploadFile(string filename, Stream stream);

        [OperationContract]
        string FindUploadedFileList(string keyword, string page, string size);

        [OperationContract]
        string GetUploadedFile(string idFile);

        [OperationContract]
        string AddUploadedFile(UploadedFileForm uploadedFileForm);

        [OperationContract]
        string UpdateUploadedFile(UploadedFileForm uploadedFileForm);

        [OperationContract]
        string DeleteUploadedFile(string idFile);

		[OperationContract]
        string GetLookups();

        [OperationContract]
        Stream GetImage(string idfile);

        [OperationContract]
        Stream GetUploadedImage(string filename);

        [OperationContract]
        string DeleteImage(string filename);

        [OperationContract]
        string DeleteImagePost(string filename);

    }
}
