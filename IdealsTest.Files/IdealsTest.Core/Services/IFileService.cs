using System.Collections.Generic;
using IdealsTest.Core.Models;

namespace IdealsTest.Core.Services
{
    public interface IFileService
    {
        IList<FileInformation> AddFiles(IEnumerable<FileInformation> files);

        IList<FileInformation> ValidateUniqueness(IList<FileInformation> files);
    }
}
