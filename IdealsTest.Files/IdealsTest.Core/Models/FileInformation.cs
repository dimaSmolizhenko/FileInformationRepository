using System;

namespace IdealsTest.Core.Models
{
    public class FileInformation
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Index { get; set; }

        public long Size { get; set; }

        public string Category { get; set; }
    }
}
