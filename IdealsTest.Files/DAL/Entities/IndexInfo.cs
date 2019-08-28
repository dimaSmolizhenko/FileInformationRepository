using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [NotMapped]
    public class IndexInfo
    {
        public string IndexBegin { get; set; }

        public int IndexLength { get; set; }
    }
}
