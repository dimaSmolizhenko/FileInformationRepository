using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Context;
using DAL.Entities;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        #region Private Members

        private readonly IDbContext _context;

        #endregion

        #region Ctors

        public Repository(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public IList<FileInfo> InsertFiles(IEnumerable<FileInfo> files)
        {
            var parameter = BuildFilesParameters(files);

            return _context.Database.SqlQuery<FileInfo>("[SetFileInfoData] @List", parameter).ToList();
        }

        public IList<string> GetFilesByDirectories(IEnumerable<IndexInfo> indexes)
        {
            var parameter = BuildIndexParameters(indexes);

            return _context.Database.SqlQuery<string>("[GetFilesByDirectories] @List", parameter).ToList();
        }

        #endregion

        #region Private Methods

        private SqlParameter BuildFilesParameters(IEnumerable<FileInfo> files)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Index");
            dt.Columns.Add("Size");
            dt.Columns.Add("Category");

            foreach (var file in files)
            {
                dt.Rows.Add(file.Id, file.Name, file.Index, file.Size, file.Category);
            }

            return new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@List",
                Value = dt,
                TypeName = "dbo.InpuFileInfo"
            };
        }

        private SqlParameter BuildIndexParameters(IEnumerable<IndexInfo> indexes)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndexBegin");
            dt.Columns.Add("IndexLength");

            foreach (var index in indexes)
            {
                dt.Rows.Add(index.IndexBegin, index.IndexLength);
            }

            return new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = "@List",
                Value = dt,
                TypeName = "dbo.FileInfoIndexStartAnaLength"
            };
        }

        #endregion
    }
}
