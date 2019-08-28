using System.Collections.Generic;
using IdealsTest.Core.Models;

namespace IdealsTest.Core.Algorithms
{
    public interface ISortable
    {
        IEnumerable<FileInformation> Sort(FileInformation[] indexes);
    }
}
