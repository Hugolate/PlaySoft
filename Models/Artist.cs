using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int artistID { get; set; }
        public string artistName { get; set; }
        public string? artistDescription { get; set; }
        
        public IList<Album> Album { get; set; }
    }
}