namespace Com.Wiseape.Gateway.FileManager.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Com.Wiseape.Gateway.FileManager.Data.Model;

    public partial class FileManagerDataContext : DbContext
    {
        public FileManagerDataContext()
            : base("name=FileManagerDataContext")
        {
        }

        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadedFile>()
                .Property(e => e.OriginalFileName)
                .IsUnicode(false);

            modelBuilder.Entity<UploadedFile>()
                .Property(e => e.TargetFileName)
                .IsUnicode(false);

            modelBuilder.Entity<UploadedFile>()
                .Property(e => e.FileInfo)
                .IsUnicode(false);
        }
    }
}
