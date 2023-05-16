using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaySoftBeta.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int artistID { get; set; }
        public string spotifyArtistID { get; set; }
        public string artistName { get; set; }
        
        public IList<ArtistAlbums> ArtistAlbum { get; set; }
        public IList<ArtistSongs> ArtistSongs { get; set; }
    }
}