using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int albumID { get; set; }
        public string spotifyAlbumID { get; set; }
        public string albumName { get; set; }
        public int totalTracks { get; set; }
        public string image { get; set; }
        public DateTime releaseDate { get; set; }
        public enum albumType
        {
            Single,
            Ep,
            Album
        }

        public IList<Song> Songs { get; set; }
        public IList<ArtistAlbums> ArtistAlbums { get; set; }
    }
}