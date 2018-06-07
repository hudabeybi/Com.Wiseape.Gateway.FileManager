using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.FileManager.Data.Model;

namespace Com.Wiseape.Gateway.FileManager.Data.Repository
{
    public class UploadedFileRepository : BaseRepository<UploadedFile>
    {
        public UploadedFileRepository() : base("UploadedFile")
        {
        }
    }
}
