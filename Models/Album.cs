using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int albumID { get; set; }
        public string albumName { get; set; }
        public string? albumDescription { get; set; }
        public IList<AlbumLines> AlbumLines { get; set; }

        public int artistID { get; set; }
        public Artist Artist { get; set; }
        
    }
}