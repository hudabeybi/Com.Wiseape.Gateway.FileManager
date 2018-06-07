namespace Com.Wiseape.Gateway.FileManager.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UploadedFile")]
    public partial class UploadedFile
    {
        [Key]
        public long IdFile { get; set; }

        [StringLength(250)]
        public string OriginalFileName { get; set; }

        [StringLength(250)]
        public string TargetFileName { get; set; }

        public int? FileSize { get; set; }

        [Column(TypeName = "text")]
        public string FileInfo { get; set; }

        public DateTime? UploadedDate { get; set; }

        public long? UserId { get; set; }
    }
}
