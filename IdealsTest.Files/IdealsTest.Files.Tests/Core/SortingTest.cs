using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdealsTest.Core.Algorithms;
using IdealsTest.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdealsTest.Files.Tests.Core
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void CanSortIndexes()
        {
            ISortable sorting = new IndexSorting();

            // Act
            IEnumerable<FileInformation> result = sorting.Sort(null);

            // Assert
            Assert.AreEqual("value", result);
        }

        private List<FileInformation> CreateFileInfoList()
        {
            return new List<FileInformation>
            {
                new FileInformation
                {
                    Category = "1",
                    Id = Guid.Empty,
                    Index = "5",
                    Name = "a",
                    Size = 100
                },
                new FileInformation
                {
                    Category = "1",
                    Id = Guid.Empty,
                    Index = "1.2.1",
                    Name = "a",
                    Size = 100
                },
                new FileInformation
                {
                    Category = "1",
                    Id = Guid.Empty,
                    Index = "2.1",
                    Name = "a",
                    Size = 100
                },
            };
        }
    }
}
