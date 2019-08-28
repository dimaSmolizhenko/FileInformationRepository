using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Entities;
using DAL.Repository;
using IdealsTest.Core.Models;

namespace IdealsTest.Core.Services
{
    public class FileService : IFileService
    {
        #region Private Members

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctors
        public FileService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public IList<FileInformation> AddFiles(IEnumerable<FileInformation> files)
        {
            var filesInfo = _mapper.Map<IEnumerable<FileInformation>, IList<FileInfo>>(files);

            var allFiles = _repository.InsertFiles(filesInfo);

            var result = _mapper.Map<IList<FileInfo>, IEnumerable<FileInformation>>(allFiles);

            return result.OrderBy(r => r.Index).ToList();
        }

        public IList<FileInformation> ValidateUniqueness(IList<FileInformation> files)
        {
            //var filesInfo = MapFileInormationToFileInfo(files);
            var filesInfo = _mapper.Map<IEnumerable<FileInformation>, IList<FileInfo>>(files);

            // get only directory index value
            var indexes = filesInfo
                .Select(f => new IndexInfo { IndexBegin = f.Index.Remove(f.Index.Length - 1), IndexLength = f.Index.Length })
                .ToList();

            var existingIndexies = _repository.GetFilesByDirectories(indexes);

            return ChangeExistingIndexies(files, existingIndexies);
        }

        #endregion

        #region Private Methods

        private IList<FileInformation> ChangeExistingIndexies(IList<FileInformation> files, IList<string> existsingIndexes)
        {
            foreach (var file in files)
            {
                while (existsingIndexes.Contains(file.Index) || files.Count(f => f.Index.Equals(file.Index)) > 1)
                {
                    var index = file.Index;
                    var last = index[index.Length - 1];
                    var number = Convert.ToInt32(last);
                    number++;
                    last = Convert.ToChar(number);
                    file.Index = string.Concat(index.Remove(index.Length - 1), last.ToString());
                }
            }

            return files;
        }

        #endregion
    }
}
