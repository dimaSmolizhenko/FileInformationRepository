using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repository
{
    public interface IRepository
    {
        IList<FileInfo> InsertFiles(IEnumerable<FileInfo> files);
        IList<string> GetFilesByDirectories(IEnumerable<IndexInfo> indexes);
    }
}
