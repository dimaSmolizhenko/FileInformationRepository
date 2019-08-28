using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("FileInfo")]
    public class FileInfo
    {
        public Guid Id { get; set; }

        [StringLength(400)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Index { get; set; }

        public long Size { get; set; }

        [StringLength(400)]
        public string Category { get; set; }
    }
}
