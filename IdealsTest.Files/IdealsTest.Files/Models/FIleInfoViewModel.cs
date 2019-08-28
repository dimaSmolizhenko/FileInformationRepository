using System.ComponentModel.DataAnnotations;

namespace IdealsTest.Files.Models
{
    public class FileInfoViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d+)*$")]
        public string Index { get; set; }

        [Required]
        public long Size { get; set; }

        [Required]
        public string Category { get; set; }
    }
}