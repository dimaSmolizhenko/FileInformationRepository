using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public interface IDbContext
    {
        DbSet<FileInfo> FilesInfo { get; set; }

        Database Database { get; }
    }
}
