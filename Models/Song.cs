using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int songID { get; set; }
        public string spotifySongID { get; set; }
        public string songName { get; set; }

        public int durationMs { get; set; }
        public DateTime publicationDate { get; set; }

        public IList<PlaylistLines> PlaylistLines { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

    }
}
