using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class FileInfoContext : DbContext, IDbContext
    {
        public FileInfoContext() : base("FileInfoDb") { }

        public DbSet<FileInfo> FilesInfo { get; set; }
    }
}
